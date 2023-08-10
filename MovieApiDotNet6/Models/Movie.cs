using System.ComponentModel.DataAnnotations;

namespace MovieApiDotNet6.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage="The 'Title' field is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The 'Genre' field is required.")]
        [MaxLength(50, ErrorMessage = "The genre can't exceed 50 characters")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "The 'Lenght In Minutes' field is required.")]
        [Range(40, 600, ErrorMessage = "The 'Lenght In Minutes' field must be between 40 and 600 minutes.")]
        public int LengthInMinutes { get; set; }
        [Required(ErrorMessage = "The 'Release Year' field is required.")]
        public int ReleaseYear { get; set; }
    }
}
