using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using ScheduleWebApp;
using ScheduleWebApp.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace ScheduleTableInformationTests
{
    public class ScheduleTableControllerTests
    {
        dfkg9ojh16b4rdContext db = new dfkg9ojh16b4rdContext();
        ILogger<ScheduleTableController> log;
        [Fact]
        public void GetScheduleView_PassNoData_ReturnNotNull()
        {
            ScheduleTableController controller = new ScheduleTableController(log,db);
            ViewResult result = controller.Schedule() as ViewResult;
            Assert.NotNull(result);
        }
    }
}
