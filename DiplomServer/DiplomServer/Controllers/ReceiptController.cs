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
    public class ReceiptController : Controller
    {
        diplomaContext dbContext = new diplomaContext();

        // POST api/<controller>
        [HttpPost]
        public string Post([FromBody]Receipt value)
        {

            Receipt receipt = new Receipt();
            receipt.Id = value.Id;
            receipt.PatientId = value.PatientId;
            receipt.DrugName = value.DrugName;
            receipt.Date = value.Date;

            try
            {
                dbContext.Add(receipt);
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
            var receipts = dbContext.Receipts.Where(receipts => receipts.PatientId.Equals(id)).OrderBy(receipts => receipts.Date);

            return JsonConvert.SerializeObject(receipts.ToList());
        }
    }
}
