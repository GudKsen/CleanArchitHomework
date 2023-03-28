using CleanArchitHomework.Domain.Models;
using CleanArchitHomework.Presentation.MVC.Models.UserModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitHomework.Presentation.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<UserModel> _userManager;

        public UsersController(UserManager<UserModel> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index() => View(_userManager.Users.ToList());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = new UserModel 
                { 
                    PhoneNumber= model.PhoneNumber,
                    Name = model.Name,
                    Email = model.Email, 
                    UserName = model.Username, 
                    Birthdate = model.Birthdate
                    //Password = model.Password,
                    //ConfirmPassword = model.ConfirmPassword
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.Role);
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            UserModel user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            UserEditModel model = new UserEditModel 
            { 
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                Name = user.Name,
                Email = user.Email,
                Username = user.Email,
                Birthdate = user.Birthdate
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Username;
                    user.Birthdate = model.Birthdate;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
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
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            UserModel user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }
    }
}
