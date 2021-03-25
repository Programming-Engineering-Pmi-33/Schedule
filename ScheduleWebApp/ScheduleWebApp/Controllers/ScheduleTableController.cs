using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ScheduleWebApp.Controllers
{
    public class ScheduleTableController : Controller
    {
        private readonly ILogger<ScheduleTableController> _logger;
        private readonly dfkg9ojh16b4rdContext _context;
        private ScheduleTable scheduleTable;
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
        public List<FacultyGroup> GetFacultyGroups()
        {
            scheduleTable.SetFacultyName("aaaa");
            return scheduleTable.Groups;
        }
        public IActionResult Table()
        {
            return View();
        }

    }
}
