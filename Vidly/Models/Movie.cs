using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName= "datetime2")]
        public DateTime ReleaseDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DateAdded { get; set; }
        public int NumberInStocks { get; set; }
        public Genre Genre { get; set; }
        [Required]
        public int GenreId { get; set; }

    }
}