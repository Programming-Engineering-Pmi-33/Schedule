using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleWebApp.Models
{
    public class ScheduleListModel
    {
       
        public List<DetailedSchedule> Schedules { get; set; }

    }
}
