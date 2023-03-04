namespace MoviesApi.Data.Dtos;

public class ReadCinemaDto
{
    public string Name { get; set; }
    
    public string Address { get; set; }

    public DateTime TimeCheck { get; set; } = DateTime.Now;
}
