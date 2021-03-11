using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_5.Models
{
    public class SeedData
    {
        //just typed in...
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            BookstoreDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<BookstoreDbContext>();

            //Check for migrations that need to happen
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            
            if(!context.Projects.Any())
            //Seed all our projects (books in this case)
            {
                context.Projects.AddRange(
                    new Project
                    {
                        Title = "Les Miserables",
                        FirstName = "Victor",
                        LastName = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 10.99m,
                        PageNumbers = 1488
                    },
                    new Project
                    {
                        Title = "Team of Rivals",
                        FirstName = "Doris Kearns",
                        LastName = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 15.99m,
                        PageNumbers = 944
                    },
                    new Project
                    {
                        Title = "The Snowball",
                        FirstName = "Alice",
                        LastName = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 22.99m,
                        PageNumbers = 832
                    },
                    new Project
                    {
                        Title = "American Ulysses",
                        FirstName = "Ronald C.",
                        LastName = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 12.99m,
                        PageNumbers = 864
                    },
                    new Project
                    {
                        Title = "Unbroken",
                        
                        FirstName = "Laura",
                        LastName = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.99m,
                        PageNumbers = 528
                    },
                    new Project
                    {
                        Title = "The Great Train Robbery",
                        FirstName = "Michael",
                        LastName = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 16.99m,
                        PageNumbers = 288
                    },
                    new Project
                    {
                        Title = "Deep Work",
                        FirstName = "Cal",
                        LastName = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 15.99m,
                        PageNumbers = 304
                    },
                    new Project
                    {
                        Title = "It's Your Ship",
                        FirstName = "Michael",
                        LastName = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 22.99m,
                        PageNumbers = 240
                    },
                    new Project
                    {
                        Title = "The Virgin Way",
                        FirstName = "Richard",
                        LastName = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = 30.99m,
                        PageNumbers = 400
                    },
                    new Project
                    {
                        Title = "Sycamore Row",
                        FirstName = "Josh",
                        LastName = "Grisham", 
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 15.99m,
                        PageNumbers = 462
                    },
                    new Project
                    {
                        Title = "1984",
                        FirstName = "George",
                        LastName = "Orwell",
                        Publisher = "Signet",
                        ISBN = "978-0451524935",
                        Classification = "Fiction",
                        Category = "Dystopian",
                        Price = 7.99m,
                        PageNumbers = 328
                    },
                    new Project
                    {
                        Title = "Lord of the Flies",
                        FirstName = "William",
                        LastName = "Golding",
                        Publisher = "Penguin",
                        ISBN = "978-0399501487",
                        Classification = "Fiction",
                        Category = "Pyschological",
                        Price = 6.99m,
                        PageNumbers = 224
                    }
                    ,
                    new Project
                    {
                        Title = "Chickenhawk",
                        FirstName = "Robert",
                        LastName = "Mason",
                        Publisher = "Penguin",
                        ISBN = "978-0143035718",
                        Classification = "Non-Fiction",
                        Category = "Military",
                        Price = 17.99m,
                        PageNumbers = 512
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
