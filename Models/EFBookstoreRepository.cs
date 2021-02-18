using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_5.Models
{
    //Implements the other repository created
    public class EFBookstoreRepository : IBookstoreRepository
    {
        //A property of the type...
        private BookstoreDbContext _context;
        //This is the Constructor, when an EFBookstorerepository instnace in created, pass a DBcontext
        public EFBookstoreRepository (BookstoreDbContext context)
        {
            _context = context;
        }
        //When Projects is called, we give what's in context projects
        public IQueryable<Project> Projects => _context.Projects;
    }
}
