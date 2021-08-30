using System;
using System.Collections.Generic;

#nullable disable

namespace DiplomServer.Model
{
    public partial class Patient
    {
        public Patient()
        {
            Journals = new HashSet<Journal>();
            Receipts = new HashSet<Receipt>();
        }

        public int PatientId { get; set; }
        public int? UserId { get; set; }
        public string BirthDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Journal> Journals { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
