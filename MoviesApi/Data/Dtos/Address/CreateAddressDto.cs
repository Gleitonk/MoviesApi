using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos;

public class CreateAddressDto
{
    [Required(ErrorMessage = "Street is required.")]
    [StringLength(100, ErrorMessage = "Street length must be up to 100 characters.")]
    public string Street { get; set; }

    [Required(ErrorMessage = "Number is required.")]
    [StringLength(30, ErrorMessage = "Number length must be up to 30 characters.")]
    public string Number { get; set; }

    [Required(ErrorMessage = "City is required.")]
    [StringLength(50, ErrorMessage = "City length must be up to 50 characters.")]
    public string City { get; set; }

    [Required(ErrorMessage = "State is required.")]
    [StringLength(30, ErrorMessage = "State length must be up to 30 characters.")]
    public string State { get; set; }

    [Required(ErrorMessage = "ZipCode is required.")]
    [StringLength(30, ErrorMessage = "ZipCode length must be up to 30 characters.")]
    public string ZipCode { get; set; }

}
