using System;
using System.Collections.Generic;

#nullable disable

namespace DiplomServer.Model
{
    public partial class Doctor
    {
        public Doctor()
        {
            Journals = new HashSet<Journal>();
        }

        public int DoctorId { get; set; }
        public int? UserId { get; set; }
        public string Building { get; set; }
        public string Department { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Journal> Journals { get; set; }
    }
}
