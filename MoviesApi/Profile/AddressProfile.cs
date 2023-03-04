using MoviesApi.Data.Dtos;
using MoviesApi.Models;

namespace MoviesApi.Profile;

public class AddressProfile : AutoMapper.Profile
{
    public AddressProfile()
    {
        CreateMap<CreateAddressDto, Address>();
        CreateMap<UpdateAddressDto, Address>();
        CreateMap<Address, ReadAddressDto>();
        CreateMap<Address, UpdateAddressDto>();
    }
}
