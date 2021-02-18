using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_5.Models
{
    //The project class acts as a Book object with specific information that "builds" out the book
    public class Project
    {
        //BookId will act as the primary key
        [Key][Required]
        public int BookId { get; set; }
        //Below, we store each piece of information (fields) for each book, with its associating data types
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Publisher { get; set; }
        //The ISBN contains a regular expression to validate it
        [Required]
        [RegularExpression(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$", ErrorMessage = "Invalid ISBN")]
        public string ISBN { get; set; }
        [Required]
        public string Classification { get; set; }
        [Required]
        public string Price { get; set; }

    }
}
