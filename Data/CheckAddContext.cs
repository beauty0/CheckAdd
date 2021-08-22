using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CheckAdd.Models;

namespace CheckAdd.Data
{
    public class CheckAddContext : DbContext
    {
        public CheckAddContext (DbContextOptions<CheckAddContext> options)
            : base(options)
        {
        }

        public DbSet<CheckAdd.Models.Bookserie> Bookserie { get; set; }

        public DbSet<CheckAdd.Models.Author> Author { get; set; }

        public DbSet<CheckAdd.Models.Genre> Genre { get; set; }
    }
}
