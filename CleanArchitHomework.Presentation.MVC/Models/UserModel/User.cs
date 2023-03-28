using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitHomework.Presentation.MVC.Models.UserModel
{
    public class UserModel : IdentityUser
    {
        
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
        public override bool EmailConfirmed { get => base.EmailConfirmed; set => base.EmailConfirmed = true; }
    }
}

