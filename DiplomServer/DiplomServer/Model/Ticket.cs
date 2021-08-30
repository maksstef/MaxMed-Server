using System;
using System.Collections.Generic;

#nullable disable

namespace DiplomServer.Model
{
    public partial class Ticket
    {
        public int Id { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }
        public string DoctorName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
