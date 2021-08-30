using System;
using System.Collections.Generic;

#nullable disable

namespace DiplomServer.Model
{
    public partial class Receipt
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string DrugName { get; set; }
        public string Date { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
