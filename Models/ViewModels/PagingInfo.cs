using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_5.Models.ViewModels
    //Custom information to pass to specific view
{
    public class PagingInfo
    {
        //Total Number of Items
        public int TotalNumItems { get; set; }
        //Total Number of Items Per page
        public int ItemsPerPage { get; set; }
        //Page currently on
        public int CurrentPage { get; set; }

        //Formula to calculate how many items to show per page
        public int TotalPages => (int)(Math.Ceiling((decimal) TotalNumItems / ItemsPerPage));
    }
}
