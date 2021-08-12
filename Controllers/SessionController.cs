using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilkAndCookies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        public List<Product> shoppingcart = new List<Product>();
        [HttpGet("Session")]
        public IEnumerable<Product> Get(string name, double price)
        {
            Product product = new Product(name, price);
            var temp = HttpContext.Session.GetObjectFromJson<List<Product>>("Shoppingcart");
            if (temp == null)
            {
                shoppingcart.Add(product);
                HttpContext.Session.SetObjectAsJson("Shoppingcart", shoppingcart);
                return shoppingcart;
            }
            else
            {
                temp.Add(product);
                HttpContext.Session.SetObjectAsJson("Shoppingcart", temp);
                return temp;     
            }
          
        }
    }
}
