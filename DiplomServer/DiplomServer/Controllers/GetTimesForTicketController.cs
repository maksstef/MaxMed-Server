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
    public class GetTimesForTicketController : Controller
    {

        diplomaContext dbContext = new diplomaContext();

        [HttpPost]
        public string Post([FromBody]Ticket value)
        {

            var tickets = dbContext.Tickets.Where(ticket => ticket.DoctorId.Equals(value.DoctorId) && ticket.Date.Equals(value.Date) && ticket.PatientId.Equals(1));

            //&& ticket.PatientId.Equals(null)

            //var doctors = (from n in dbContext.Users
            //               join c in dbContext.Doctors on n.UserId equals c.UserId
            //               where (c.Department == value.Department && c.Building == value.Building)
            //               select new
            //               {
            //                   n.UserId,
            //                   n.FullName,
            //                   n.Login,
            //                   c.DoctorId,
            //                   c.Building,
            //                   c.Department
            //               });

            return JsonConvert.SerializeObject(tickets.ToList());

        }
    }
}
