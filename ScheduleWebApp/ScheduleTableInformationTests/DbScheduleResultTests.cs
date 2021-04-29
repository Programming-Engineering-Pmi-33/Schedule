using Xunit;
using ScheduleWebApp.DAL;
using ScheduleWebApp.BLL;
using ScheduleWebApp.Controllers;
using ScheduleWebApp;

namespace ScheduleTableInformationTests
{   
    public class DbScheduleResultTests
    {
        dfkg9ojh16b4rdContext db = new dfkg9ojh16b4rdContext();

        [Theory]
        [InlineData(1,"Abba")]
        [InlineData(2,"Ozzy")]
        public void  GetGroupSchedule_IvalidData_ReturnEmpty(int period, string group)
        {
            var results = DetailedScheduleFunctions.GetGroupSchedule(period, group, db);
            Assert.Empty(results);
        }
        [Fact]
        public void GetGroupSchedule_ValidData_ReturnNotEmpty()
        {
            var results = DetailedScheduleFunctions.GetGroupSchedule(1,"aa",db);
            Assert.NotEmpty(results);
        }
        [Theory]
        [InlineData("name","surname")]
        [InlineData("Oliver","Sikes")]
        public void GetLecturerSchedule_NotExistingUser_ReturnEmpty(string name, string surname)
        {
            var results = DetailedScheduleFunctions.GetLecturerSchedule(name,surname,db);
            Assert.Empty(results);
        }
        [Theory]
        [InlineData("Oleh", "Halamaha")]
        public void GetLecturerSchedule_NotExistingUser_ReturnNotEmpty(string name, string surname)
        {
            var result = DetailedScheduleFunctions.GetLecturerSchedule(name, surname, db);
            Assert.NotEmpty(result);
        }
    }
}
