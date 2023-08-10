using System.ComponentModel.DataAnnotations;

namespace MovieApiDotNet6.Data.Dtos
{
    public class ReadMovieDto
    {
         public string Title { get; set; }
         public string Genre { get; set; }
        public int LengthInMinutes { get; set; }
        public int ReleaseYear { get; set; }
        public DateTime EventTimestamp { get; set; } = DateTime.Now;
    }
}
