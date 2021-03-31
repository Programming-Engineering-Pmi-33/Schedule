using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleWebApp.BLL
{
    public class NewSubject
    {
        private dfkg9ojh16b4rdContext Db { get; set; }
        public NewSubject(dfkg9ojh16b4rdContext db)
        {
            Db = db;
        }

        public bool AddNewSubject()
        {
            return true;
        }
    }
}
