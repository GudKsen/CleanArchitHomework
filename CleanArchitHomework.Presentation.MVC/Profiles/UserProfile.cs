using AutoMapper;
using CleanArchitHomework.Domain.Models;
using CleanArchitHomework.Presentation.MVC.Models.UserModel;

namespace CleanArchitHomework.Presentation.MVC.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserModel>();
           // CreateMap<UserModel, User>().ForMember(u => u.Login, opt => opt.MapFrom(x => x.Email));
        }

        
    }
}
