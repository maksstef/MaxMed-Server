using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomServer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiplomServer.Controllers
{
    [Route("api/[controller]")]
    public class GetDoctorsController : Controller
    {

        diplomaContext dbContext = new diplomaContext();

        [HttpGet]
        public string Get()
        {
            //var res = dbContext.Users.Join(dbContext.Doctors, x => x.UserId, y => y.UserId, (x, y) => x).ToList(); //.Id_details.Join(db.Employee_details, x => x.R_ID, y => y.R_ID, (x, y) => x).ToList();
            //return JsonConvert.SerializeObject(res);


            var products = dbContext.Users
              .Include(p => p.Doctors)
              .ToList();

            var query = (from n in dbContext.Users
                         join c in dbContext.Doctors on n.UserId equals c.UserId

                         select new
                         {
                             n.UserId,
                             n.FullName,
                             n.Login,
                             c.DoctorId,
                             c.Building,
                             c.Department
                         });

            return JsonConvert.SerializeObject(query.ToList());

            //return JsonConvert.SerializeObject(dbContext.Set<User>().Where(user => user.Role.Equals("Doctor")));
        }

    }
}
