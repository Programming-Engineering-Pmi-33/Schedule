using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleWebApp.Models
{
    public class TeacherModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100.")]
        [DataType(DataType.Text, ErrorMessage = "Please, enter correct name.")]
        [RegularExpression("^[A-Z, a-z]*$", ErrorMessage = "Please, enter correct name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(100)]
        [DataType(DataType.Text, ErrorMessage = "Please, enter correct surname.")]
        [RegularExpression("^[A-Z, a-z]*$", ErrorMessage = "Please, enter correct name.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Text, ErrorMessage = "Please, enter correct position.")]
        [RegularExpression("^[A-Z, a-z]*$", ErrorMessage = "Please, enter correct name.")]
        public string Position { get; set; }

        [DataType(DataType.Password)]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password { get; set; }
        public string? Image { get; set; }
    }
}
