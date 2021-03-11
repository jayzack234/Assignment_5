using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Assignment_5.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        //Pass in the project object and the quantity
        public void AddItem(Project proj, int quant)
        {
            //New instance of a cart line, created here
            //Go out to lines and look first in the list for the BookId and the one that's been added
            CartLine line = Lines
                .Where(p => p.Project.BookId == proj.BookId)
                .FirstOrDefault();

            //Check if they match, and if not add a new CartLine
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Project = proj,
                    Quantity = quant
                });
            }
            //Otherwise, update quantity
            else
            {
                line.Quantity += quant;
            }
        }

        public void RemoveLine(Project proj) =>
            //Remove all that match
            Lines.RemoveAll(x => x.Project.BookId == proj.BookId);
        
        //Option to clear everything in the cart
        public void Clear() => Lines.Clear();

        //Sum the price here in the cart
        public int ComputeTotalSum() => Lines.Sum(e => Convert.ToInt32(e.Project.Price) * e.Quantity);
        
        public class CartLine
        {
            //Three properties for CartLine, or one line of the cart
            public int CartLineID { get; set; }
            public Project Project { get; set; }
            public int Quantity { get; set; }
        }
    }
}
