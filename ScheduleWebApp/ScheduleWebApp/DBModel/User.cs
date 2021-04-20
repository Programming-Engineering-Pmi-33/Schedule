using System;
using System.Collections.Generic;

#nullable disable

namespace ScheduleWebApp
{
    public partial class User
    {
        public User()
        {
            Requests = new HashSet<Request>();
            UserSubjects = new HashSet<UserSubject>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool? IsAdmin { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<UserSubject> UserSubjects { get; set; }
    }
}
