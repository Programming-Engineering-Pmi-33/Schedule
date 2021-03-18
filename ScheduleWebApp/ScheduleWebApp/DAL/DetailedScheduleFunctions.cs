using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ScheduleWebApp
{
    public class DetailedScheduleFunctions
    {
        //public static dfkg9ojh16b4rdContext db { get; set; }

        public static List<DetailedSchedule> GetLecturerSchedule(string lecturerName, string lecturerSurname, dfkg9ojh16b4rdContext db)
        {
            return db.DetailedSchedules.FromSqlInterpolated($"select * from get_lecturer_schedule({lecturerName},{lecturerSurname})").ToList();
        }

        public static List<DetailedSchedule> GetGroupSchedule(int period, string groupName, dfkg9ojh16b4rdContext db)
        {
            return db.DetailedSchedules.FromSqlInterpolated($"select * from get_schedule({period},{groupName})").ToList();
        }
    }
}
