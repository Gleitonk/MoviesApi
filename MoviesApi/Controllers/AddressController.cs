using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data;
using MoviesApi.Data.Dtos;
using MoviesApi.Models;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public AddressController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddAddress(
        [FromBody] CreateAddressDto addressDto
    )
    {
        var address = _mapper.Map<Address>(addressDto);

        _context.Addresses.Add(address);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAddressById), new { id = address.Id }, address);
    }


    [HttpGet]
    public IEnumerable<ReadAddressDto> GetAddresses(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 50
    )
    {
        var addresses = _context.Addresses.Skip(skip).Take(take);

        var addressesDto = _mapper.Map<List<ReadAddressDto>>(addresses);

        return addressesDto;
    }

    [HttpGet("{id}")]
    public IActionResult GetAddressById(Guid id)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);

        if (address == null) return NotFound();

        var addressDto = _mapper.Map<ReadAddressDto>(address);

        return Ok(addressDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAddress(
        Guid id,
        [FromBody] UpdateAddressDto addressDto
    )
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);

        if (address == null) return NotFound();

        _mapper.Map(addressDto, address);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateAddressPartial(
        Guid id,
        [FromBody] JsonPatchDocument<UpdateAddressDto> patch
    )
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);

        if (address == null) return NotFound();

        var addressToUpdate = _mapper.Map<UpdateAddressDto>(address);

        patch.ApplyTo(addressToUpdate, ModelState);

        if (!TryValidateModel(addressToUpdate))
        {
            return ValidationProblem();
        }

        _mapper.Map(addressToUpdate, address);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAddress(
        Guid id
    )
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        if (address == null) return NotFound();

        _context.Addresses.Remove(address);
        _context.SaveChanges();
        return NoContent();
    }



}
