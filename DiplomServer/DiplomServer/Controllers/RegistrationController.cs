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

    public class RegistrationController : Controller
    {
        diplomaContext dbContext = new diplomaContext();

        // POST api/<controller>
        [HttpPost]
        public string Post([FromBody]User value)
        {

            if (!dbContext.Users.Any(user => user.Login.Equals(value.Login)))
            {
                User user = new User(value.UserId, value.FullName, value.Login, value.Password, value.Role);

                if (value.Role == "Patient")
                {
                    Patient patient = new Patient();
                    patient = value.Patients.First();

                    user.Patients.Add(patient);

                }
                else if (value.Role == "Doctor")
                {
                    Doctor doctor = new Doctor();
                    doctor = value.Doctors.First();

                    user.Doctors.Add(doctor);

                }

                try
                {
                    dbContext.Add(user);
                    dbContext.SaveChanges();
                    return JsonConvert.SerializeObject("User has been registered!");
                }
                catch (Exception e)
                {
                    return JsonConvert.SerializeObject(e.Message);
                }
            }
            else
            {
                return JsonConvert.SerializeObject("User is existing!");
            }

        }

    }
}
