using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Repository
namespace Assignment_5.Models
{
    //An interface is a template to be inherited
    public interface IBookstoreRepository
    {
        //Puts this information in an object that we can query out of
        IQueryable<Project> Projects { get; }
    }
}
