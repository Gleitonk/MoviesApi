namespace MoviesApi.Data.Dtos;

public class ReadAddressDto
{
    public string Street { get; set; }

    public string Number { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string ZipCode { get; set; }

    public DateTime CheckDate { get; set; } = DateTime.Now;

}
