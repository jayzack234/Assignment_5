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
                        Author = "Victor Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction, Classic",
                        Price = "$9.95"
                    },
                    new Project
                    {
                        Title = "Team of Rivals",
                        Author = "Doris Kearns Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction, Biography",
                        Price = "$14.58"
                    },
                    new Project
                    {
                        Title = "The Snowball",
                        Author = "Alice Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction, Biography",
                        Price = "$21.54"
                    },
                    new Project
                    {
                        Title = "American Ulysses",
                        Author = "Ronald C. White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction, Biography",
                        Price = "$11.61"
                    },
                    new Project
                    {
                        Title = "Unbroken",
                        Author = "Laura Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction, Historical ",
                        Price = "$13.33"
                    },
                    new Project
                    {
                        Title = "The Great Train Robbery",
                        Author = "Michael Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction, Historical Fiction",
                        Price = "$15.95"
                    },
                    new Project
                    {
                        Title = "Deep Work",
                        Author = "Cal Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction, Self-Help",
                        Price = "$14.99"
                    },
                    new Project
                    {
                        Title = "It's Your Ship",
                        Author = "Michael Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction, Self-Help ",
                        Price = "$21.66"
                    },
                    new Project
                    {
                        Title = "The Virgin Way",
                        Author = "Richard Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Non-Fiction, Business",
                        Price = "$29.16"
                    },
                    new Project
                    {
                        Title = "Sycamore Row",
                        Author = "Josh Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613 ",
                        Classification = "Fiction, Thrillers",
                        Price = "$15.03"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
