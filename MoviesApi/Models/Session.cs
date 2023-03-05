namespace MoviesApi.Models;

public class Session
{
    public Guid? MovieId { get; set; }
    public virtual Movie Movie { get; set; }

    public Guid? CinemaId { get; set; }
    public virtual Cinema Cinema { get; set; }
}
