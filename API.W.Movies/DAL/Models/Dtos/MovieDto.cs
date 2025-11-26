using System.ComponentModel.DataAnnotations;

namespace API.W.Movies.DAL.Models.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Duration { get; set; }
        public required string Clasification { get; set; }
        public string? Description { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
