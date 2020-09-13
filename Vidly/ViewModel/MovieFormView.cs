using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MovieFormView
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Range(1,20)]
        public int? NumberInStocks { get; set; }
      
        [Required]
        public int? GenreId { get; set; }
        public string Title  
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }


        public MovieFormView()
        {
            Id = 0;
        }
        public MovieFormView(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
            NumberInStocks = movie.NumberInStocks;
        }

    }
}