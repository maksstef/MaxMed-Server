using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomServer.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiplomServer.Controllers
{
    [Route("api/[controller]")]
    public class UpdateUserController : Controller
    {

        diplomaContext dbContext = new diplomaContext();

        [HttpPut]
        public void Put([FromBody]User value)
        {
            User user = dbContext.Users.Where(u => u.UserId.Equals(value.UserId)).First();

            user.FullName = value.FullName;

            Patient patient = dbContext.Patients.Where(u => u.UserId.Equals(value.UserId)).First();
            patient.BirthDate = value.Patients.First().BirthDate;
            patient.Address = value.Patients.First().Address;
            patient.Phone = value.Patients.First().Phone;
            patient.Email = value.Patients.First().Email;

            try
            {
                dbContext.Update(user);
                dbContext.SaveChanges();
                dbContext.Update(patient);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }

        }

    }
}
