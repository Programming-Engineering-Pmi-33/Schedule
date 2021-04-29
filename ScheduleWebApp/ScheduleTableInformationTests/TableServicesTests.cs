using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ScheduleWebApp;

namespace ScheduleTableInformationTests
{
    public class TableServicesTests
    {
        dfkg9ojh16b4rdContext db = new dfkg9ojh16b4rdContext();
        [Fact]
        public void GetFacultiesList_NoDataPased_ReturnNotEmpty()
        {
            ScheduleTableServices services = new ScheduleTableServices(db);
            List<string> results = services.GetFacultiesNames();
            
            Assert.NotEmpty(results);
        }
        [Theory]
        [InlineData("Lepopo")]
        [InlineData("Slytherin")]
        public void GetGroups_FacultyNamePassed_ReturnEmpty(string facultyName)
        {
            ScheduleTableServices services = new ScheduleTableServices(db);
            services.FacultyName = facultyName;
            var result = services.GroupsNames;
            Assert.Empty(result);
        }
        [Theory]
        [InlineData("Lepopo")]
        [InlineData("Slytherin")]
        public void GetGroups_FacultyNamePassed_ReturnNotEqual(string facultyName)
        {
            ScheduleTableServices services = new ScheduleTableServices(db);
            services.FacultyName = "Faculty of Physics";
            var physicsGroup = services.GroupsNames;
            services.FacultyName = facultyName;
            var result = services.GroupsNames;
            Assert.NotEqual(physicsGroup,result);
        }
        
    }
}
