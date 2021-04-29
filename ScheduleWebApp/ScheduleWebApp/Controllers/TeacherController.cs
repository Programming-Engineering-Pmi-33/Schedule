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
using System.Security.Claims;

namespace ScheduleWebApp.Controllers
{
    public class TeacherController : Controller
    {
        private TeacherService teacherService;

        public TeacherController( dfkg9ojh16b4rdContext _db)
        {
            teacherService =new TeacherService(_db);
        }

        public ViewResult Show()
        {
            return View(teacherService.Teacher);
        }

        [HttpGet]
        public ActionResult Profile()
        {
            return View(teacherService.Teacher);
        }


        [HttpPost]
        public ViewResult Profile(TeacherModel user)
        {
           // var cookie =HttpContext.User.FindFirst(ClaimTypes.NameIdentifier); 

            if (ModelState.IsValid)
            {
                try
                {
                    teacherService.Edit(user);
                    ViewBag.Massage = "Editing successful";
                }
                catch(ArgumentException ex)
                {
                    ViewBag.Massage = ex.Message;
                }
            }
            else
            {
                ViewBag.Massage = "Editing faild";
            }
            return View();
        }

    }
}