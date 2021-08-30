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
    public class GetDoctorsForTicketController : Controller
    {
        diplomaContext dbContext = new diplomaContext();

        [HttpPost]
        public string Post ([FromBody]Doctor value)
        {

            //var doctors = dbContext.Doctors.Where(doctors => doctors.Building.Equals(value.Building) && doctors.Department.Equals(value.Department));


            var doctors = (from n in dbContext.Users
                             join c in dbContext.Doctors on n.UserId equals c.UserId
                             where (c.Department == value.Department && c.Building == value.Building)
                             select new
                             {
                                 n.UserId,
                                 n.FullName,
                                 n.Login,
                                 c.DoctorId,
                                 c.Building,
                                 c.Department
                             });

            return JsonConvert.SerializeObject(doctors.ToList());

        }
    }
}
