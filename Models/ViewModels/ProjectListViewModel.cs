using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_5.Models.ViewModels
{
    //Actual view handed to the project
    //Contains both the projects and the page information
    //View model that contains necessary data for that view
    public class ProjectListViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
