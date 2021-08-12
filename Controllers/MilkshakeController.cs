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
    public class MilkshakeController : ControllerBase
    {

        public List<string> milkshakes = new List<string>() { "Chocolate", "Strawberry", "Vanilla" };

        //Get favorite milkshake, set by the user.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flavor"></param>
        /// <returns>Milkshake flavor or null</returns>
        [HttpGet("Milkshakes")]
        public IEnumerable<string> Get(string flavor)
        {
            //If the flavor user chose exists in "milkshakes", respond with set FavoriteMilkshake cookie with that flavor -
            // and return the chosen milkshake to the user.
            if (milkshakes.Contains(flavor))
            {
                //Here we set some options for the cookie. This adds an expiration date for the cookie.
                CookieOptions co = new CookieOptions();
                co.Expires = new DateTimeOffset(DateTime.Now.AddMinutes(1));

                Response.Cookies.Append("FavoriteMilkshake", flavor, co);
                return milkshakes.Contains(flavor) ? milkshakes.Where(f => f == flavor) : null;
            }
            else
            {
                return null;
            }
        }
        //Get cookie
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The requested cookie["FavoriteMilkshake"] or 'unknown'</returns>
        [HttpGet("GetFromCookie")]
        public string Get()
        {
            //Checks if the cookie exists and if it does it returns "FavoriteMilkshake"
            if (Request.Cookies["FavoriteMilkshake"] is null)
            {
                return "unknown";
            }
            else
            {
                return Request.Cookies["FavoriteMilkshake"];
            }
        }
    }
}
