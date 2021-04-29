using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using ScheduleWebApp.BLL;

namespace ScheduleAppTestProject
{
    public class UserServiceTests
    {
        private readonly UserService us = new UserService(new ScheduleWebApp.DAL.UserFunctions(new ScheduleWebApp.dfkg9ojh16b4rdContext()));
        
        [Test]
        public void SaltFromUsername()
        {
            //arrange
            string username = "Yaropud";

            //act
            var salt = us.GetUserSalt(username);

            //assert
            Assert.IsNotNull(salt);
        }

        [Test]
        public void SaltFromUsernameUnknown()
        {
            //arrange
            string username = "testuser";

            //act
            var salt = us.GetUserSalt(username);

            //assert
            Assert.IsNull(salt);
        }

        [Test]
        public void ValidateUserLoginInfo()
        {
            //arrange
            string email = "Green";

            //act
            var isValid = us.IsValid(email, "Qwerty123!A");

            //assert
            Assert.AreEqual(isValid, IdentityResult.Success);
        }

        [Test]
        public void ValidateUserLoginInfoExistingSurmane()
        {
            //arrange
            string email = "Yaropud";

            //act
            var isValid = us.IsValid(email, "Qwerty123!A");

            //assert
            Assert.AreEqual(isValid.Succeeded, false);
        }

        [Test]
        public void ValidateUserLoginInfoInvalidPasswordUpperCase()
        {
            //arrange
            string email = "Green";

            //act
            var isValid = us.IsValid(email, "qwerty123!A");

            //assert
            Assert.AreEqual(isValid.Succeeded, false);
        }

        [Test]
        public void ValidateUserLoginInfoInvalidPasswordSymbols()
        {
            //arrange
            string email = "Green";

            //act
            var isValid = us.IsValid(email, "QwertyA");

            //assert
            Assert.AreEqual(isValid.Succeeded, false);
        }

        [Test]
        public void ValidateUserLoginInfoInvalidPasswordCharacters()
        {
            //arrange
            string email = "Green";

            //act
            var isValid = us.IsValid(email, "123!");

            //assert
            Assert.AreEqual(isValid.Succeeded, false);
        }

        [Test]
        public void GetUserInfo()
        {
            //act
            var userId = us.GetUserId(new ScheduleWebApp.Models.LoginModel { Surname="user", Password="qwert123" }, 1234242.ToString());

            //assert
            Assert.AreEqual(userId, 0);
        }

        [Test]
        public void GetUserFromDatabase()
        {
            //act
            var user = us.GetUser(1);

            //assert
            Assert.IsNotNull(user);
        }

        [Test]
        public void GetUserFromDatabaseUnknown()
        {
            //act
            var user = us.GetUser(-1);

            //assert
            Assert.IsNull(user);
        }

        [Test]
        public void GetClaimsAndUserPrincipal()
        {
            //act
            var user = us.GetPrincipal(1);

            //assert
            Assert.IsNotNull(user);
        }
    }
}
