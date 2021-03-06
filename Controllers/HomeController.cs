﻿using Assignment_5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment_5.Models.ViewModels;

namespace Assignment_5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBookstoreRepository _repository;

        //Creating a variable to limit the number of items shown on a page
        public int PageSize = 5;

        //We'll pass the repository to the view over the following two methods
        public HomeController(ILogger<HomeController> logger, IBookstoreRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        //Passing that varaiable created above, default is page 1
        //Passing in a repository projects, but specifically only a set number for each page (5 items per page as specified by the variable above)
        public IActionResult Index(string category, int page = 1)
        {
            return View(new ProjectListViewModel
            {
                Projects = _repository.Projects
                //if the category is null or if the classification is equal to the category, then select it
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.BookId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                //New paginginfo object
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalNumItems = category == null? _repository.Projects.Count() :
                    //This fixes the page number
                        _repository.Projects.Where (x => x.Category == category).Count()
                },
                //Current category is set to whatever is selected, this is for url parameters of filtering by category
                CurrentCategory = category
            }); ;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
