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
    public class JournalController : Controller
    {

        diplomaContext dbContext = new diplomaContext();

        // POST api/<controller>
        [HttpPost]
        public string Post([FromBody]Journal value)
        {

            Journal journal = new Journal();
            //ругается на юзер айди так как, он является внешним ключом мб попробовать вставлять такой же как айди тикета/доктора, и затем когда юзер записывается,
            //менять на айди юзера
            journal.Id = value.Id;
            journal.DoctorId = value.DoctorId;
            journal.PatientId = value.PatientId;
            journal.Date = value.Date;
            journal.Issue = value.Issue;
            journal.Decision = value.Decision;

            try
            {
                dbContext.Add(journal);
                dbContext.SaveChanges();
                return JsonConvert.SerializeObject("Успешно добавлено!");
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(e.Message);
            }
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            var tickets = dbContext.Journals.Where(journal => journal.PatientId.Equals(id)).OrderBy(journal => journal.Date);

            return JsonConvert.SerializeObject(tickets.ToList());
        }

        public void Put([FromBody]Journal value)
        {

            Journal journal = dbContext.Journals.Where(journal => journal.Id.Equals(value.Id)).First();

            journal.Date = value.Date;
            journal.Issue = value.Issue;
            journal.Decision = value.Decision;

            try
            {
                dbContext.Update(journal);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                
            }

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                Journal journal = dbContext.Journals.FirstOrDefault(journal => journal.Id.Equals(id));
                dbContext.Journals.Remove(journal);
                dbContext.SaveChanges();

            }
            catch (Exception e)
            {

            }
        }
    }
}
