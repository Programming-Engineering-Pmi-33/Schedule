using ScheduleWebApp;
using ScheduleWebApp.BLL;
using System.Linq;

namespace ScheduleWebApp.DAL
{
    /// <summary>
    /// Announces UserService сlass.
    /// </summary>
    public class UserFunctions
    {
        private dfkg9ojh16b4rdContext _db { get; set; }

        public UserFunctions(dfkg9ojh16b4rdContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Checks if surname is in database.
        /// </summary>
        /// <param name="surname">surname value.</param>
        /// <returns>bool value.</returns>
        public bool SurnameExists(string surname)
        {
            var resultName = (from data in _db.Users
                              where data.Surname == surname
                              select data.Name).ToList();

            return resultName.Count > 0;
        }

        /// <summary>
        /// Registers user.
        /// </summary>
        /// <param name="user">user instance.</param>
        public void RegisterUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        /// <summary>
        /// Deletes user from database.
        /// </summary>
        /// <param name="user">user instance.</param>
        public void DeleteUser(User user)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        /// <summary>
        /// Gets user salt from database.
        /// </summary>
        /// <param name="surname"> surname value.</param>
        /// <returns>salt or 0 if surname is not found.</returns>
        public string GetUserSalt(string surname)
        {
            //long salt1 = EncryptionService.CreateRandomSalt();

            //string hashedPassword = EncryptionService.ComputeSaltedHash("qwerty123!A", salt1);

            //RegisterUser(new User { Name = "Sophia", Surname = "Yaropud", Salt = salt1.ToString(), Password = hashedPassword });

            var salt = (from data in _db.Users
                        where data.Surname == surname
                        select data.Salt).FirstOrDefault();

            return salt;
        }

        public User GetUser(int userId)
        {
            var user = (from data in _db.Users
                        where data.Id == userId
                        select data).FirstOrDefault();

            return user;
        }

        /// <summary>
        /// Gets user id from database.
        /// </summary>
        /// <param name="surname">surname value.</param>
        /// <param name="hashedPassword">hashedPassword value.</param>
        /// <returns>id or 0 if surname is not found.</returns>
        public int GetUserId(string surname, string hashedPassword)
        {
            var userId = (from data in _db.Users
                          where data.Surname != null && data.Surname == surname && data.Password == hashedPassword
                          select data.Id).FirstOrDefault();

            return userId;
        }
    }
}