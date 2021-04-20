using System;
using System.Collections.Generic;

#nullable disable

namespace ScheduleWebApp
{
    public partial class UserSubject
    {
        public UserSubject()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public int? SubjectId { get; set; }
        public int? UserId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
