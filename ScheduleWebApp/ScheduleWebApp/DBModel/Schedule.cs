using System;
using System.Collections.Generic;

#nullable disable

namespace ScheduleWebApp
{
    public partial class Schedule
    {
        public int Id { get; set; }
        public int? UserSubjectId { get; set; }
        public int? GroupId { get; set; }
        public DateTime? Time { get; set; }
        public string Day { get; set; }
        public int? Semestr { get; set; }
        public string Type { get; set; }
        public string Audience { get; set; }

        public virtual Group Group { get; set; }
        public virtual UserSubject UserSubject { get; set; }
    }
}
