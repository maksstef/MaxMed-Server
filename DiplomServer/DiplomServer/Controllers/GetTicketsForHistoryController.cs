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
    public class GetTicketsForHistoryController : Controller
    {
        diplomaContext dbContext = new diplomaContext();

        [HttpGet("{id}")]
        public string Get(int id)
        {
            var tickets = (from n in dbContext.Tickets
                           join c in dbContext.Doctors on n.DoctorId equals c.DoctorId
                           where (n.PatientId == id)
                           orderby n.Date
                           select new
                           {
                               n.Id,
                               n.PatientId,
                               n.Date,
                               n.DoctorName,
                               c.Department
                           });

            return JsonConvert.SerializeObject(tickets.ToList());
        }
    }
}
