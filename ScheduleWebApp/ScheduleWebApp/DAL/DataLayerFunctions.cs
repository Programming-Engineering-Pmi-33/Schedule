using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ScheduleWebApp
{
    public class DataLayerFunctions
    {
        private dfkg9ojh16b4rdContext _db { get; set; }
        public DataLayerFunctions(dfkg9ojh16b4rdContext db)
        {
            _db = db;
        }
        public List<Faculty> GetFaculties()
        {
            return _db.Faculties.ToList();
        }
        public List<FacultyGroup> GetFacultyGroups( string  faculty_name)
        {
            return _db.FacultyGroups.FromSqlInterpolated($"SELECT * FROM get_faculty_groups({faculty_name})").ToList();
        }

        public List<Request> GetRequests()
        {
            return _db.Requests.ToList();
        }
    }
}
