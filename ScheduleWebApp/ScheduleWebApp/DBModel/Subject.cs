using System;
using System.Collections.Generic;

#nullable disable

namespace ScheduleWebApp
{
    public partial class Subject
    {
        public Subject()
        {
            UserSubjects = new HashSet<UserSubject>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserSubject> UserSubjects { get; set; }
    }
}
