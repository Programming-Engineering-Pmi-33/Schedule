namespace DrinkWater.Services
{
    using Microsoft.AspNetCore.Identity;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Announces ValidationService сlass.
    /// </summary>
    public class ValidationService
    {
        private const string EMAILREGEX = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        private readonly UsersService usersService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationService"/> class.
        /// </summary>
        /// <param name="usersService">user service instance.</param>
        public ValidationService(UsersService usersService)
        {
            this.usersService = usersService;
        }

        /// <summary>
        /// Validates username, email and password and sets errors to labels if any.
        /// </summary>
        /// <param name="username">username value.</param>
        /// <param name="email">email value.</param>
        /// <param name="password">password value.</param>
        /// <returns>bool value.</returns>
        public IdentityResult IsValid(string email, string password)
        {
            var isCorrectEmail = IsValidEmail(email);
            var isCorrectPassword = IsValidPassword(password);

            return isCorrectEmail.Succeeded && isCorrectPassword.Succeeded
                ? IdentityResult.Success
                : IdentityResult.Failed(isCorrectEmail.Errors.ToArray().Concat(isCorrectPassword.Errors.ToArray()).ToArray());
        }

        ///// <summary>
        /////  Checks correctness of username.
        ///// </summary>
        ///// <param name="labelUsername">username label.</param>
        ///// <param name="username">username value.</param>
        ///// <returns>bool value.</returns>
        //private bool IsValidUsername(Label labelUsername, string username)
        //{
        //    bool isCorrect = false;

        //    if (string.IsNullOrWhiteSpace((string)username) == true)
        //    {
        //        SetError(labelUsername, "Username is required");
        //    }
        //    else if (username.Count(char.IsLetter) < 2)
        //    {
        //        SetError(labelUsername, "Username must contain at least 2 letters");
        //    }
        //    else if (usersService.UsernameExists(username))
        //    {
        //        SetError(labelUsername, "Username is reserved");
        //    }
        //    else
        //    {
        //        isCorrect = true;
        //        labelUsername.Visibility = Visibility.Hidden;
        //    }

        //    return isCorrect;
        //}

        /// <summary>
        /// Checks correctness of email.
        /// </summary>
        /// <param name="email">email value.</param>
        /// <returns>bool value.</returns>
        private IdentityResult IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) == true)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Email is required" });
            }
            else if (!Regex.IsMatch(email, EMAILREGEX, RegexOptions.IgnoreCase))
            {
                return IdentityResult.Failed(new IdentityError { Description = "Wrong e-mail address" });
            }
            else if (usersService.UsernameExists(email))
            {
                return IdentityResult.Failed(new IdentityError { Description = "Email is reserved" });
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