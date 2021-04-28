using Microsoft.AspNetCore.Http;
using ScheduleWebApp.Models;
using System;
using System.Linq;

namespace ScheduleWebApp.BLL
{
    public class TeacherService
    {
        private dfkg9ojh16b4rdContext db;
        public TeacherModel Teacher { get; set; }

        public TeacherService(dfkg9ojh16b4rdContext dbContext)
        {
            db = dbContext;
            User user = db.Users.First(x => x.Id == 1);
            Teacher = new TeacherModel {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Position = user.Position,
                Password = user.Password,
                Image = user.Image
            };
        }

        public TeacherModel GetTeacher(int id)
        {
            var user =db.Users.Find(id);
            return new TeacherModel
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Position = user.Position,
                Password = user.Password
            };
        }

        public void Edit(TeacherModel teacher)
        {
            try
            {
                User user = db.Users.First(x => x.Id == teacher.Id);
                user.Name = teacher.Name;
                user.Surname = teacher.Surname;
                user.Position = teacher.Position;
                user.Image = "";
                if (teacher.Password != null)
                    user.Password = teacher.Password;
                db.Users.Update(user);
                db.SaveChanges();
            }
            catch
            {
                throw new ArgumentException("User not exist");
            }
            
        }
    }
}
