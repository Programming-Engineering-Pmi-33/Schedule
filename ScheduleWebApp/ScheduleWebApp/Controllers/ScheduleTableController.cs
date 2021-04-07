using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using ScheduleWebApp.Models;

namespace ScheduleWebApp.Controllers
{
    public class ScheduleTableController : Controller
    {
        private readonly ILogger<ScheduleTableController> _logger;
        private readonly dfkg9ojh16b4rdContext _context;
        public ScheduleTable scheduleTable;
        public int ChoosenPeriod { get; set; }

        public ScheduleTableController(ILogger<ScheduleTableController> logger, dfkg9ojh16b4rdContext context)
        {
            _logger = logger;
            _context = context;
            scheduleTable = new ScheduleTable(_context);

        }
        public IActionResult Schedule()
        {
            //scheduleTable.GetSchedule("Lubomyr", "Halamaha");
            ViewData["FacultyNames"] = new FacultyDropDownListModel { SelectedValue = null, Values = scheduleTable.Faculties };
            return View();
        }
        [HttpGet]
        public PartialViewResult GetPeriod(int selected)
        {
            return PartialView("Period", new PeriodDropDownModel { SelectedValue = selected, Values = new List<int> { 1, 2 } });
        }
        [HttpGet]
        public PartialViewResult GetGroups(string selected)
        {
            scheduleTable.SetFacultyName(selected);

            return PartialView("Group", new FacultyDropDownListModel {SelectedValue = null, Values=scheduleTable.GroupsNames});
        }
        [HttpGet]
        public PartialViewResult GetTable(int selectedPeriod, string selected)
        {
            scheduleTable.GetSchedule(selectedPeriod, selected);
            return PartialView("Table", new ScheduleListModel { Schedules = scheduleTable.DetailedSchedules });
        }
        //тутай буде функція для розкладу викладача, аби лиш мати логін
    }
}
