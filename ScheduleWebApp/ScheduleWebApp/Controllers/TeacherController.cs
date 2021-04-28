using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScheduleWebApp.BLL;
using ScheduleWebApp.Models;
using System.IO;

namespace ScheduleWebApp.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ILogger<TeacherController> logger;
        private TeacherService teacherService;

        public TeacherController(ILogger<TeacherController> _logger, dfkg9ojh16b4rdContext _db)
        {
            logger = _logger;
            teacherService =new TeacherService(_db);
        }

       
        public ActionResult Show()
        {
            return View(teacherService.Teacher);
        }

        public ActionResult Profile()
        {
            return View(teacherService.Teacher);
        }


        [HttpPost]
        public ActionResult Profile(TeacherModel user)
        {
            // var cookie = Session<User>.Deconvert(\\файли кукі)
            // user.Id = cookie.Id
            if (ModelState.IsValid)
            {
                teacherService.Edit(user);
                return RedirectToAction(nameof(Show));
            }
            else
            {
                return View();
            }
        }

    }
}