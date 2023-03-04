using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApi.Models;

public class Movie
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    [MaxLength(80, ErrorMessage = "Title length must be up to 80 characters.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Genre is required.")]
    [MaxLength(80, ErrorMessage = "Genre length must be up to 80 characters.")]
    public string Genre { get; set; }

    [Required(ErrorMessage = "Duration is required.")]
    [Range(70, 600, ErrorMessage = "Duration must be between 70 and 600 minutes.")]
    public int Duration { get; set; }

    [Required]
    public DateTime CreateDate { get; set; } = DateTime.Now;

    public virtual ICollection<Session> Sessions { get; set; }
}
