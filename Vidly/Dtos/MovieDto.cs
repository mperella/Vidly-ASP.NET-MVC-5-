using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int GenreId { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public DateTime? AddDate { get; set; }

        [Required]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }
    }
}