using System;
using System.Collections.Generic;

#nullable disable

namespace DiplomServer.Model
{
    public partial class Journal
    {
        public int Id { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }
        public string Date { get; set; }
        public string Issue { get; set; }
        public string Decision { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
