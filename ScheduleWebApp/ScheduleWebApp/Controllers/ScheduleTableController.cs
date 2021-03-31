﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

namespace ScheduleWebApp.Controllers
{
    public class ScheduleTableController : Controller
    {
        private readonly ILogger<ScheduleTableController> _logger;
        private readonly dfkg9ojh16b4rdContext _context;
        public ScheduleTable scheduleTable;

        public ScheduleTableController(ILogger<ScheduleTableController> logger, dfkg9ojh16b4rdContext context)
        {
            _logger = logger;
            _context = context;
            scheduleTable = new ScheduleTable(_context);

        }
        public List<Faculty> Show()
        {
            ScheduleTable scheduleTable = new ScheduleTable(_context);
            return scheduleTable.Faculties;
        }
        public IActionResult Table()
        {
            scheduleTable.SetFacultyName("aaaa");
           
            scheduleTable.GetSchedule("Liubomyr", "Halamaha");
            Models.ScheduleList scheduleList = new Models.ScheduleList { Schedules = scheduleTable.DetailedSchedules };
            return View(scheduleList);
        }
        private void SelectGroups()
        {
            List<string> groups = new List<string>();
            foreach (var group in scheduleTable.Groups)
            {
                groups.Add(group.GroupName);
            }
            ViewBag.Groups = new SelectList(groups, "GroupName");
        }
        private void SelectFaculty()
        {
            ViewBag.Faculty = new SelectList(scheduleTable.Faculties.ToString(), "Name");
        }
        private void SelectPeriod()
        {
            ViewBag.Period = new SelectList(new List<int>() { 1, 2 }, "Periods");
        }
        private void GetTable()
        {

        }
        [HttpPost]
        public void GetPeriodDropDown(int Period)
        {
            var x = Period;
            ViewBag.Period = new SelectList(new List<int>() { 1, 5, 4 }, "Periods");
            return;
        }
        [HttpGet]
        public void GetViewBags()
        {
            SelectPeriod();
            SelectFaculty();
            //SelectGroups();
        }
    }
}
