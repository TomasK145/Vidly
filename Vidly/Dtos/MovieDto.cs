using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //[Display(Name = "Genre")]
        //[Required]
        //public byte GenreId { get; set; }

        //public DateTime DateAdded { get; set; }

        //[Display(Name = "Release Date")]
        //[Required]
        //public DateTime ReleaseDate { get; set; }

        //[Required]
        //[Range(1, 20)]
        //public byte NumberInStock { get; set; }

        //public byte NumberAvailable { get; set; }
    }
}