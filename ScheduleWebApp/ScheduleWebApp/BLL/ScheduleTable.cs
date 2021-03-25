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
        public List<FacultyGroup> Groups { get; set; }
        public List<Faculty> Faculties { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

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
        private string chooosenGroup;
        private string choosenPeriod;
        dfkg9ojh16b4rdContext dbContext;
        DataLayerFunctions functions;
        public ScheduleTable()
        {

        }
        public ScheduleTable(dfkg9ojh16b4rdContext context)
        {
            dbContext = context;
            functions = new DataLayerFunctions(dbContext);
            Faculties = GetFaculties();
        }
        private List<Faculty> GetFaculties()
        {
            return functions.GetFaculties();
        }
        private void GetGroups()
        {
            Groups = functions.GetFacultyGroups(chosenFaculty);
        }
        public void GetSchedule()
        {
           DetailedSchedules = DetailedScheduleFunctions.GetLecturerSchedule(Name, Surname, dbContext);
           DetailedSchedules = DetailedScheduleFunctions.GetGroupSchedule(Convert.ToInt32(choosenPeriod), chooosenGroup, dbContext);
        }
        public void SetFacultyName(string name)
        {
            FacultyName = name;
        }
    }
}
