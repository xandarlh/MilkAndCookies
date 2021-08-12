using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilkAndCookies
{
    public class Product
    {
        public string pName { get; set; }

        public double pPrice { get; set; }

        public Product(string name, double price)
        {
            pName = name;
            pPrice = price;
        }
    }
}
