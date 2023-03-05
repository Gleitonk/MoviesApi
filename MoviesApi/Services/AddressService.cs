using AutoMapper;
using FluentResults;
using MoviesApi.Data;
using MoviesApi.Data.Dtos;
using MoviesApi.Models;

namespace MoviesApi.Services;

public class AddressService
{

    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public AddressService(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadAddressDto AddAddress(CreateAddressDto addressDto)
    {
        var address = _mapper.Map<Address>(addressDto);
        _context.Addresses.Add(address);
        _context.SaveChanges();
        return _mapper.Map<ReadAddressDto>(address);
    }

    public IEnumerable<ReadAddressDto> GetAddresses(int skip, int take)
    {
        var addresses = _context.Addresses.Skip(skip).Take(take).ToList();
        var addressesDto = _mapper.Map<List<ReadAddressDto>>(addresses);
        return addressesDto;
    }

    public ReadAddressDto? GetAddressById(Guid id)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        if (address == null) return null;
        return _mapper.Map<ReadAddressDto>(address);
    }

    public Result UpdateAddress(Guid id, UpdateAddressDto addressDto)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);

        if (address == null) return Result.Fail("Address Not Found");

        _mapper.Map(addressDto, address);
        _context.SaveChanges();
        return Result.Ok();
    }

    public Result UpdateAddressPartial(Guid id, UpdateAddressDto addressToUpdate)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        _mapper.Map(addressToUpdate, address);
        return Result.Ok();
    }

    public Result DeleteAddress(Guid id)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        if (address == null) return Result.Fail("Address Not Found");

        _context.Addresses.Remove(address);
        _context.SaveChanges();
        return Result.Ok();
    }

}
