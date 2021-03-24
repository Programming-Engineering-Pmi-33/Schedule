using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScheduleWebApp.BLL;

namespace ScheduleWebApp.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ILogger<TeacherController> logger;
        private readonly dfkg9ojh16b4rdContext db;
        private User teacher=new User();

        public TeacherController(ILogger<TeacherController> _logger, dfkg9ojh16b4rdContext _db)
        {
            logger = _logger;
            db = _db;
            //teacher =user;
        }

       
        public ActionResult Show()
        {
            teacher = db.Users.First(x => x.Id == 1);
            return View(teacher);
        }

        public ActionResult Profile()
        {
            teacher = db.Users.First(x=>x.Id==1);
            return View(teacher);
        }


        [HttpPost]
        public ActionResult Profile(User user)
        {
            try
            {
                db.Users.Update(user);
                db.SaveChanges();
                return RedirectToAction(nameof(Show));
            }
            catch
            {
                return View();
            }
        }

    }
}