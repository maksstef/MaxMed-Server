using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DiplomServer.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiplomServer.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        diplomaContext dbContext = new diplomaContext();

        // POST api/<controller>
        [HttpPost]
        public string Post([FromBody]User value)
        {
            if (dbContext.Users.Any(user => user.Login.Equals(value.Login)))
            {
                User user = dbContext.Users.Where(user => user.Login.Equals(value.Login)).First();

                if (user.Password.Equals(value.Password))
                {
                    return JsonConvert.SerializeObject(user);
                }
                else
                {
                    return JsonConvert.SerializeObject("Wrong password!");
                }
            }
            else
            {
                return JsonConvert.SerializeObject("User not existing!");
            }
        }

    }
}
