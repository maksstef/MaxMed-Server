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
    public class GetTicketsForDocController : Controller
    {
        diplomaContext dbContext = new diplomaContext();

        [HttpGet("{id}")]
        public string Get(int id)
        {
            //var tickets = dbContext.Tickets.Where(tickets => tickets.DoctorId.Equals(id) && !tickets.PatientId.Equals(1)).OrderBy(tickets => tickets.Date);

            var tickets = (from n in dbContext.Tickets
                           join c in dbContext.Users on n.PatientId equals c.UserId
                           where (n.DoctorId == id && n.PatientId != 1)
                           orderby n.Date
                           select new
                           {
                               n.Id,
                               n.Date,
                               n.Time,
                               c.FullName
                           });

            return JsonConvert.SerializeObject(tickets.ToList());
        }
    }
}
