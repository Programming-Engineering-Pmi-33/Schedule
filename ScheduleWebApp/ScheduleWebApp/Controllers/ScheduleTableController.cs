using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

using ScheduleWebApp.Models;

namespace ScheduleWebApp.Controllers
{
    public class ScheduleTableController : Controller
    {
        private readonly ILogger<ScheduleTableController> _logger;
        private readonly dfkg9ojh16b4rdContext _context;
        public ScheduleTableServices scheduleTable;
       

        public ScheduleTableController(ILogger<ScheduleTableController> logger, dfkg9ojh16b4rdContext context)
        {
            _logger = logger;
            _context = context;
            scheduleTable = new ScheduleTableServices(_context);

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
        [HttpPost]
        public IActionResult AddSubject(string time, string subject, string lecturer, string type, string audience)
        {

            return new EmptyResult(); 
        }
        [HttpGet]
        public PartialViewResult GetDay(string day, string order)
        {
           string newDay = "";
            var result = (from element in scheduleTable.DetailedSchedules
                         where element.Day == newDay
                         select element).ToList();
            return PartialView("Table", new ScheduleListModel { Schedules = result });
        }
        //тутай буде функція для розкладу викладача, аби лиш мати логін
    }
}
