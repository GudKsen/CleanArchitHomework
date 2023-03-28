using System.ComponentModel.DataAnnotations;

namespace CleanArchitHomework.Presentation.MVC.Models.UserModel
{
    public class UserEditModel
    {
        public string Id
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Please provide username", AllowEmptyStrings = false)]
        public string Username
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Please provide Password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be 8 char long.")]
        public string Password
        {
            get;
            set;
        }
        [Compare("Password", ErrorMessage = "Confirm password dose not match.")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string ConfirmPassword
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Please provide full name", AllowEmptyStrings = false)]
        public string Name
        {
            get;
            set;
        }

        public DateTime Birthdate
        {
            get;
            set;
        }

        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
        ErrorMessage = "Please provide valid email")]
        public string Email
        {
            get;
            set;
        }

        [Required]
        public string PhoneNumber
        {
            get;
            set;
        }
    }
}
