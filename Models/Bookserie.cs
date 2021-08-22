using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CheckAdd.Models
{
    public class Bookserie
    {
        [Key]

       public int BookserieId { get; set; }

        public int AuthorId { get; set; }
        public int GenreId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }
        [ForeignKey("Authord")]
        public virtual Author Author { get; set; }
    }
}
