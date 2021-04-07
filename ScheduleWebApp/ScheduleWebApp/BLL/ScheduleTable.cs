using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ScheduleWebApp
{
    public class ScheduleTable
    {

        public List<DetailedSchedule> DetailedSchedules { get; set; }
        public List<string> GroupsNames { get; set; }
        public List<string> Faculties { get; set; }

        private string chosenFaculty;
        public string FacultyName
        {
            get { return chosenFaculty; }
            set
            {
                chosenFaculty = value;
                GetGroups();
            }
        }
        dfkg9ojh16b4rdContext dbContext;
        DataLayerFunctions functions;
        public ScheduleTable()
        {

        }
        public ScheduleTable(dfkg9ojh16b4rdContext context)
        {
            dbContext = context;
            functions = new DataLayerFunctions(dbContext);
            Faculties = GetFacultiesNames();
        }
        private List<string> GetFacultiesNames()
        {
            List<string> facultiesNames = new List<string>();
            var facultyObjects = functions.GetFaculties();
            foreach(var faculty in facultyObjects)
            {
                facultiesNames.Add(faculty.Name);
            }
            return facultiesNames;
        }
        private void GetGroups()
        {
            GroupsNames = new List<string>();
            var groups = functions.GetFacultyGroups(chosenFaculty);
            foreach(var group in groups)
            {
                GroupsNames.Add(group.GroupName);
            }
        }
        public void GetSchedule(string name, string surname)
        {
           DetailedSchedules = DetailedScheduleFunctions.GetLecturerSchedule(name, surname, dbContext);
        }
        public void GetSchedule(int chosenPeriod, string chosenGroup)
        {
            DetailedSchedules = DetailedScheduleFunctions.GetGroupSchedule(chosenPeriod, chosenGroup, dbContext);
        }
        public void SetFacultyName(string name)
        {
            FacultyName = name;
        }
    }
}
