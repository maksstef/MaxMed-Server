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
    public class GetPatientController : Controller
    {

        diplomaContext dbContext = new diplomaContext();

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {

            var query = (from n in dbContext.Users
                         join c in dbContext.Patients on n.UserId equals c.UserId
                         where (n.UserId == id) 
                         select new
                         {
                             n.UserId,
                             n.FullName,
                             n.Login,
                             c.PatientId,
                             c.Address,
                             c.BirthDate,
                             c.Email,
                             c.Phone
                         });

            return JsonConvert.SerializeObject(query.ToList());
        }

        [HttpGet]
        public string Get()
        {
            var query = (from n in dbContext.Users
                         join c in dbContext.Patients on n.UserId equals c.UserId

                         select new
                         {
                             n.UserId,
                             n.FullName,
                             n.Login,
                             c.PatientId,
                             c.BirthDate
                         });

            return JsonConvert.SerializeObject(query.ToList());

            //return JsonConvert.SerializeObject(dbContext.Set<User>().Where(user => user.Role.Equals("Doctor")));
        }


        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }


    }
}
