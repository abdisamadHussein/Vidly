using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ReleaseDate { get; set; }
  
        public int NumberInStocks { get; set; }

        public GenreDto Genre { get; set; }
        public int GenreId { get; set; }

    }
}