using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CleanArchitHomework.Presentation.MVC.Models.UserModel
{
    public class UserLoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
