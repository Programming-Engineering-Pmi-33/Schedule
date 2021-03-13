using System;
using System.Collections.Generic;

#nullable disable

namespace ScheduleWebApp
{
    public partial class Request
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string RequestText { get; set; }

        public virtual User User { get; set; }
    }
}
