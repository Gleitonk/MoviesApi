namespace MoviesApi.Data.Dtos;

public class ReadCinemaDto
{
    public string Name { get; set; }

    public ReadAddressDto Address { get; set; }

    public DateTime CheckDate { get; set; } = DateTime.Now;

    public ICollection<ReadSessionDto> Sessions { get; set; }
}
