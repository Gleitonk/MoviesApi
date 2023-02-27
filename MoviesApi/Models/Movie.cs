using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models;
public class Movie
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    [StringLength(80, ErrorMessage = "Genre length must be up to 80.")]
    public string Title { get; set; }


    [Required(ErrorMessage = "Genre is required.")]
    [StringLength(50, ErrorMessage = "Genre length must be up to 50.")]
    public string Genre { get; set; }


    [Required(ErrorMessage = "Duration is required.")]
    [Range(70, 600, ErrorMessage = "Duration must be between 70 and 600 minutes.")]
    public int Duration { get; set; }

    [Required(ErrorMessage = "Director is required.")]
    [StringLength(50, ErrorMessage = "Director name length must be up to 50.")]
    public string Director { get; set; }
}

