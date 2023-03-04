using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos;

public class GetCinemaDto
{
    public int Id { get; set; }

    public string Name { get; set; }
}
