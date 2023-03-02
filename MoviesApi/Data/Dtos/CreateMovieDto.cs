using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos;

public class CreateMovieDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    [StringLength(80, ErrorMessage = "Title length must be up to 80 characters.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Genre is required.")]
    [StringLength(80, ErrorMessage = "Genre length must be up to 80 characters.")]
    public string Genre { get; set; }

    [Required(ErrorMessage = "Duration is required.")]
    [Range(70, 600, ErrorMessage = "Duration must be between 70 and 600 minutes.")]
    public int Duration { get; set; }
}
