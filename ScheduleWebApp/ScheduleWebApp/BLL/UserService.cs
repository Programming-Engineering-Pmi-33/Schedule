using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using ScheduleWebApp.DAL;
using ScheduleWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ScheduleWebApp.BLL
{
    /// <summary>
    /// Announces ValidationService сlass.
    /// </summary>
    public class UserService
    {
        private readonly UserFunctions _userFunctions;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userFunctions">user service instance.</param>
        public UserService(UserFunctions userFunctions)
        {
            _userFunctions = userFunctions;
        }

        public string GetUserSalt(string surname) => _userFunctions.GetUserSalt(surname);

        /// <summary>
        /// Validates username, email and password and sets errors to labels if any.
        /// </summary>
        /// <param name="username">username value.</param>
        /// <param name="email">email value.</param>
        /// <param name="password">password value.</param>
        /// <returns>bool value.</returns>
        public IdentityResult IsValid(string email, string password)
        {
            var isCorrectEmail = IsValidSurname(email);
            var isCorrectPassword = IsValidPassword(password);

            return isCorrectEmail.Succeeded && isCorrectPassword.Succeeded
                ? IdentityResult.Success
                : IdentityResult.Failed(isCorrectEmail.Errors.ToArray().Concat(isCorrectPassword.Errors.ToArray()).ToArray());
        }

        public int GetUserId(LoginModel user, string salt)
        {
            string hashedPassword = EncryptionService.ComputeSaltedHash(user.Password, long.Parse(salt));

            return _userFunctions.GetUserId(user.Surname, hashedPassword);
        }

        public User GetUser(int userId) => _userFunctions.GetUser(userId);

        public ClaimsPrincipal GetPrincipal(int userId)
        {
            var user = GetUser(userId);

            ClaimsIdentity identity = new ClaimsIdentity(GetUserClaims(user), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            return principal;
        }

        private List<Claim> GetUserClaims(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Surname, user.Surname)
            };
            //claims.AddRange(GetUserRoleClaims(user));

            return claims;
        }

        private IEnumerable<Claim> GetUserRoleClaims(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Position?.ToString())
            };

            return claims;
        }

        /// <summary>
        /// Checks correctness of surname.
        /// </summary>
        /// <param name="surname">surname value.</param>
        /// <returns>bool value.</returns>
        private IdentityResult IsValidSurname(string surname)
        {
            if (_userFunctions.SurnameExists(surname))
            {
                return IdentityResult.Failed(new IdentityError { Description = "Surname is reserved" });
            }

            return IdentityResult.Success;
        }

        /// <summary>
        /// Checks correctness of password.
        /// </summary>
        /// <param name="password">password value.</param>
        /// <returns>bool value.</returns>
        private IdentityResult IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return IdentityResult.Failed(new IdentityError { Description = "Password is required" });
            }
            else if (password.ToString().Length < 8)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Password is too short" });
            }
            else if (password.ToString().Count(char.IsLetter) < 2)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Password must contain at least 2 letters" });
            }
            else if (password.ToString().Count(char.IsUpper) < 2)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Password must contain at least 2 or more uppercase letter" });
            }

            return IdentityResult.Success;
        }
    }
}