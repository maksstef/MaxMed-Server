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
    public class TicketController : Controller
    {
        diplomaContext dbContext = new diplomaContext();

        // POST api/<controller>
        [HttpPost]
        public string Post([FromBody]Ticket value)
        {
            //скорее всего оно галимо сработает и будет смотреть по всей таблице
            if (!dbContext.Tickets.Any(ticket => ticket.DoctorName.Equals(value.DoctorName) && 
                 ticket.Date.Equals(value.Date) &&
                 ticket.Time.Equals(value.Time)) ) 
            {
                Ticket ticket = new Ticket();
                //ругается на юзер айди так как, он является внешним ключом мб попробовать вставлять такой же как айди тикета/доктора, и затем когда юзер записывается,
                //менять на айди юзера
                ticket.Id = value.Id;
                ticket.DoctorId = value.DoctorId;
                ticket.PatientId = value.PatientId;
                ticket.DoctorName = value.DoctorName;
                ticket.Date = value.Date;
                ticket.Time = value.Time;

                try
                {
                    dbContext.Add(ticket);
                    dbContext.SaveChanges();
                    return JsonConvert.SerializeObject("Успешно добавлено!");
                }
                catch (Exception e)
                {
                    return JsonConvert.SerializeObject(e.Message);
                }
            }
            else
            {
                return JsonConvert.SerializeObject("Такая запись уже существует!");
            }

        }


        public void Put([FromBody]Ticket value)
        {

            Ticket ticket = dbContext.Tickets.Where(u => u.Id.Equals(value.Id)).First();
            ticket.PatientId = value.PatientId;


            try
            {
                dbContext.Update(ticket);
                dbContext.SaveChanges();
                //return JsonConvert.SerializeObject("Вы записаны!");
            }
            catch (Exception ex)
            {
                //return JsonConvert.SerializeObject(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            var tickets = dbContext.Tickets.Where(tickets => tickets.DoctorId.Equals(id) && tickets.PatientId.Equals(1)).OrderBy(tickets => tickets.Date);

            return JsonConvert.SerializeObject(tickets.ToList());
        }

    }
}
