using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos
{
    public class GetMovieDto
    {
        public string Title { get; set; }

        public string Genre { get; set; }

        public int Duration { get; set; }

        public string Director { get; set; }

        public DateTime Time { get; set; } = DateTime.Now;
    }
}
