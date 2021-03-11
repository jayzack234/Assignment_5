using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Assignment_5.Models;
using Assignment_5.Infrastructure;
//Model for our Razor Page
namespace Assignment_5.Pages
{
    public class DonateModel : PageModel
    {
        private IBookstoreRepository repository;

        //Constructor
        public DonateModel (IBookstoreRepository repo)
        {
            repository = repo;
        }

        //build instance of a cart
        //Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        //Pass in returnUrl
        public void OnGet(string returnUrl)
        {
            //Retrun url and if null return a slash
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        }

        //On Post, or submit, look at the repository, get the cart or add new cart, add an item to the Cart, then
        //set JSON with that updated Cart, pass in the return Url
        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Project project = repository.Projects.FirstOrDefault(p => p.BookId == bookId);

            Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();

            Cart.AddItem(project, 1);

            HttpContext.Session.SetJson("Cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
        //Functionality to Remove Book from Cart
        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            Project book = repository.Projects.FirstOrDefault(b => b.BookId == bookId);
            Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            Cart.RemoveLine(book);
            HttpContext.Session.SetJson("Cart", Cart);
            return RedirectToPage(new { returnUrl = returnUrl });  
        }
    }
}
