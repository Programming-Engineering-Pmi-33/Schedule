using System.ComponentModel.DataAnnotations;

namespace ScheduleWebApp.Models
{
    public class TeacherModel : LoginModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100.")]
        [DataType(DataType.Text, ErrorMessage = "Please, enter correct name.")]
        [RegularExpression("^[A-Z, a-z]*$", ErrorMessage = "Please, enter correct name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Text, ErrorMessage = "Please, enter correct position.")]
        [RegularExpression("^[A-Z, a-z]*$", ErrorMessage = "Please, enter correct name.")]
        public string Position { get; set; }

        public string Image { get; set; }
    }
}
