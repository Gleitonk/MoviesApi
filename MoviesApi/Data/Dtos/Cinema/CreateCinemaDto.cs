using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos;

public class CreateCinemaDto
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(70, ErrorMessage = "Name length must be up to 70 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Address is required.")]
    [StringLength(100, ErrorMessage = "Address length must be up to 100 characters.")]
    public string Address { get; set; }

    public DateTime CreateDate { get; set; } = DateTime.Now;
}
