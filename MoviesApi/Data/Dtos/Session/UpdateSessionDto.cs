using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos;

public class UpdateSessionDto
{
    [Required]
    public Guid MovieId { get; set; }
}
