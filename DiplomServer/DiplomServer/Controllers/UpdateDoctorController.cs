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
    public class UpdateDoctorController : Controller
    {
        diplomaContext dbContext = new diplomaContext();

        //public string Put([FromBody]User value)
        public void Put([FromBody]User value)
        {
            //User user = dbContext.Users.Where(u => u.UserId.Equals(value.UserId)).First();

            //user.FullName = value.FullName;
            //user.Login = value.Login;
            //user.Password = value.Password;

            //Doctor doctor = new Doctor();
            //doctor.Building = value.Doctors.First().Building;
            //doctor.Department = value.Doctors.First().Department;
            ////doctor = value.Doctors.First();

            //user.Doctors.Add(doctor);
            //try
            //{
            //    dbContext.Update(user);
            //    dbContext.SaveChanges();
            //    return JsonConvert.SerializeObject("Doctor updated!");
            //}
            //catch (Exception ex)
            //{
            //    return JsonConvert.SerializeObject(ex.Message);
            //}

            User user = dbContext.Users.Where(u => u.UserId.Equals(value.UserId)).First();

            user.FullName = value.FullName;
            user.Login = value.Login;
            user.Password = value.Password;

            Doctor doctor = dbContext.Doctors.Where(u => u.UserId.Equals(value.UserId)).First();
            doctor.Building = value.Doctors.First().Building;
            doctor.Department = value.Doctors.First().Department;
            //doctor = value.Doctors.First();

            try
            {
                dbContext.Update(user);
                dbContext.SaveChanges();
                dbContext.Update(doctor);
                dbContext.SaveChanges();
                //return JsonConvert.SerializeObject("Doctor updated!");
            }
            catch (Exception ex)
            {
                //return JsonConvert.SerializeObject(ex.Message);
            }

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                Doctor doctor = dbContext.Doctors.FirstOrDefault(u => u.UserId.Equals(id));
                dbContext.Doctors.Remove(doctor);
                dbContext.SaveChanges();

                User user = dbContext.Users.FirstOrDefault(u => u.UserId.Equals(id));
                dbContext.Users.Remove(user);
                dbContext.SaveChangesAsync();

            }
            catch (Exception e)
            {

            }
        }

    }
}
