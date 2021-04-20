using ScheduleWebApp.Models;
using System.Linq;

namespace ScheduleWebApp.BLL
{
    public class TeacherService
    {
        private readonly dfkg9ojh16b4rdContext db;
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
                Image = ""
            };
        }

        public void Edit(TeacherModel teacher)
        {
            User user = db.Users.First(x => x.Id == teacher.Id);
            user.Name = teacher.Name;
            user.Surname = teacher.Surname;
            user.Position = teacher.Position;
            if(teacher.Password!=null)
                user.Password = teacher.Password;
            db.Users.Update(user);
            db.SaveChanges();
        }
    }
}
