using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos;

public class UpdateAddressDto
{
    [Required(ErrorMessage = "Street is required.")]
    [MaxLength(100, ErrorMessage = "Street length must be up to 100 characters.")]
    public string Street { get; set; }

    [Required(ErrorMessage = "Number is required.")]
    [MaxLength(30, ErrorMessage = "Number length must be up to 30 characters.")]
    public string Number { get; set; }

    [Required(ErrorMessage = "City is required.")]
    [MaxLength(50, ErrorMessage = "City length must be up to 50 characters.")]
    public string City { get; set; }

    [Required(ErrorMessage = "State is required.")]
    [MaxLength(30, ErrorMessage = "State length must be up to 30 characters.")]
    public string State { get; set; }

    [Required(ErrorMessage = "ZipCode is required.")]
    [MaxLength(30, ErrorMessage = "ZipCode length must be up to 30 characters.")]
    public string ZipCode { get; set; }

    public DateTime CreateDate { get; set; } = DateTime.Now;

}
