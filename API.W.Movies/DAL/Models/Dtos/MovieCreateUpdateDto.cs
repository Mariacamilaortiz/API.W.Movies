using System.ComponentModel.DataAnnotations;

namespace API.W.Movies.DAL.Models.Dtos
{
    public class MovieCreateUpdateDto
    {
        [Required(ErrorMessage = "El nombre de la película es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El número máximo de caracteres para el nombre es de 100.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "La duración de la película es obligatoria.")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "La clasificación es obligatoria.")]
        [MaxLength(10, ErrorMessage = "El número máximo de caracteres para la clasificación es de 10.")]
        public required string Clasification { get; set; }

        public string? Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}

