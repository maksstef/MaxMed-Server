using System;
using System.Collections.Generic;

#nullable disable

namespace DiplomServer.Model
{
    public partial class User
    {
        public User()
        {
            Doctors = new HashSet<Doctor>();
            Patients = new HashSet<Patient>();
        }

        public User(int userId, string fullName, string login, string password, string role)
        {
            UserId = userId;
            FullName = fullName;
            Login = login;
            Password = password;
            Role = role;
            Doctors = new HashSet<Doctor>();
            Patients = new HashSet<Patient>();
        }

        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
