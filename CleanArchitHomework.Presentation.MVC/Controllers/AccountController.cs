using AutoMapper;
using CleanArchitHomework.Domain.Models;
using CleanArchitHomework.Presentation.MVC.Models.UserModel;
//using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitHomework.Presentation.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        public AccountController(IMapper mapper, UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            UserModel userM = new UserModel
            {
                UserName = userModel.UserName,
                Email = userModel.Email,
                Name = userModel.Name,
                Birthdate = userModel.Birthdate,
                PhoneNumber = userModel.PhoneNumber
            };
            var user = _mapper.Map<UserModel>(userM);

            var result = await _userManager.CreateAsync(userM, userModel.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View(userModel);
            }
            await _userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginModel user)
        {
            if (ModelState.IsValid)
            {
                //var userFind = await _userManager.FindByLoginAsync(user.Username);
                
                if (user != null)
                {

                    var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, user.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Login", "Account");
                    }
                }
                else
                {
                    return BadRequest("no email");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(user);
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UserEditModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Username;
                    user.Birthdate = model.Birthdate;
                    user.PhoneNumber = model.PhoneNumber;
                    user.Name = model.Name;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Profile");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return RedirectToAction("Profile");
        }

    }
}
