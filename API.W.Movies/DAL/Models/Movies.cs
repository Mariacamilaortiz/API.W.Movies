using System.ComponentModel.DataAnnotations;

namespace API.W.Movies.DAL.Models
{
    public class Movie : AuditBase
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        [MaxLength(10)]
        public required string Clasification { get; set; }

        public string? Description { get; set; }

        public DateTime? ReleaseDate { get; set; }
    }
}

