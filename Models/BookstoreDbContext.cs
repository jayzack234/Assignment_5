using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_5.Models
{
    //Inherits from the DbContext class provided by the system
    public class BookstoreDbContext : DbContext
    {
        //Build a constructor here, when the object is built, this will be called
        public BookstoreDbContext (DbContextOptions<BookstoreDbContext> options) : base (options)
        {

        }
        //Property that returns a DbSet of a project
        public DbSet<Project> Projects { get; set; }
    }
}
