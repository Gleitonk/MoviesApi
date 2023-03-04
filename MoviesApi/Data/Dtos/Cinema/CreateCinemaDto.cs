using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos;

public class CreateCinemaDto
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(70, ErrorMessage = "Name length must be up to 70 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "AddressId is required.")]
    public Guid AddressId { get; set; }

}
