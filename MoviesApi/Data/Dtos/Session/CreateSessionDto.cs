using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos;

public class CreateSessionDto
{
    [Required]
    public Guid MovieId { get; set; }

    [Required]
    public Guid CinemaId { get; set; }
}
