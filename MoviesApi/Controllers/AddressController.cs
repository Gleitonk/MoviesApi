using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data.Dtos;
using MoviesApi.Services;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private readonly AddressService _addressService;
    private readonly IMapper _mapper;

    public AddressController(AddressService addressService, IMapper mapper)
    {
        _addressService = addressService;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddAddress(
        [FromBody] CreateAddressDto addressDto
    )
    {
        var readDto = _addressService.AddAddress(addressDto);
        return CreatedAtAction(nameof(GetAddressById), new { id = readDto.Id }, readDto);
    }


    [HttpGet]
    public IEnumerable<ReadAddressDto> GetAddresses(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 50
    )
    {
        return _addressService.GetAddresses(skip, take);
    }

    [HttpGet("{id}")]
    public IActionResult GetAddressById(Guid id)
    {
        var addressDto = _addressService.GetAddressById(id);
        if (addressDto == null) return NotFound();
        return Ok(addressDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAddress(
        Guid id,
        [FromBody] UpdateAddressDto addressDto
    )
    {
        var result = _addressService.UpdateAddress(id, addressDto);
        if (result.IsFailed) return NotFound();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateAddressPartial(
        Guid id,
        [FromBody] JsonPatchDocument<UpdateAddressDto> patch
    )
    {
        var address = _addressService.GetAddressById(id);

        if (address == null) return NotFound();

        var addressToUpdate = _mapper.Map<UpdateAddressDto>(address);

        patch.ApplyTo(addressToUpdate, ModelState);

        if (!TryValidateModel(addressToUpdate))
        {
            return ValidationProblem();
        }

        _addressService.UpdateAddressPartial(id, addressToUpdate);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAddress(
        Guid id
    )
    {
        var address = _addressService.DeleteAddress(id);
        if (address.IsFailed) return NotFound();
        return NoContent();
    }
}
