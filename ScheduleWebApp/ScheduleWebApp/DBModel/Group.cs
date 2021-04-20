using System;
using System.Collections.Generic;

#nullable disable

namespace ScheduleWebApp
{
    public partial class Group
    {
        public Group()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public int? FacultyId { get; set; }
        public string Group1 { get; set; }

        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
