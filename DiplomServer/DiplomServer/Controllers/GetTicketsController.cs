using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomServer.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiplomServer.Controllers
{
    [Route("api/[controller]")]
    public class GetTicketsController : Controller
    {
        diplomaContext dbContext = new diplomaContext();

        [HttpGet("{id}")]
        public string Get(int id)
        {
            var tickets = dbContext.Tickets.Where(tickets => tickets.PatientId.Equals(id)).OrderBy(tickets => tickets.Date);

            return JsonConvert.SerializeObject(tickets.ToList());
        }
    }
}
