using Assignment_5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Piece of logic we can reuse and drop somewhere into specified pages
namespace Assignment_5.Components
{
    public class NavigationMenuViewComponent : ViewComponent 
    {

        private IBookstoreRepository repository;

        //constructor
        public NavigationMenuViewComponent (IBookstoreRepository r)
        {
            repository = r;
        }
        //Get a list of items from the repository
        public IViewComponentResult Invoke()
        {
            //Helps with highlighting whatever link is seleted
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(repository.Projects
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
