using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheckAdd.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Bookserie> Bookserie { get; set; }
    }
}
