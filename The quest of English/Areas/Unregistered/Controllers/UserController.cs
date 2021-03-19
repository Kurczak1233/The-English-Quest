using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using The_quest_of_English.Models;
using TheEnglishQuest;
using TheEnglishQuestCore.Managers;

namespace The_quest_of_English.Controllers
{
    [Area("Unregistered")]
    public class UserController : Controller
    {
        private readonly ApplicationUserViewModelMapper _applicationUserViewModelMapper;
        private readonly ApplicationUserManager _applicationUserManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly IEmailSender _emailSender;
        public UserController(ApplicationUserManager applicationUserManager,
            ApplicationUserViewModelMapper applicationUserViewModelMapper,
            SignInManager<IdentityUser> signInManager
            )
        {
            _applicationUserManager = applicationUserManager;
            _applicationUserViewModelMapper = applicationUserViewModelMapper;
            _signInManager = signInManager;
        }
        
        public RegisterInputModel Input { get; set; }
        public LoginModelInput Input2 { get; set; }


        public IActionResult Register()
        {
            return View(Input);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        [ActionName("Register")]
        public async Task<IActionResult> RegisterFunction(RegisterInputModel model)
        {
            await _applicationUserManager.DeleteUser("xxx"); //Deletin all user
            if (ModelState.IsValid)
            {
                ApplicationUserViewModel user = new ApplicationUserViewModel()
                {
                    UserName = model.Login,
                    Email = model.Email,
                };
                var userDto = _applicationUserViewModelMapper.Map(user);
                var resultAdd = await _applicationUserManager.AddUser(userDto, model.Password, SD.OrdinaryUser);
                if (resultAdd.Succeeded)
                {
                    
                    return RedirectToAction("MainView", "Platform", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid register attempt.");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid register attempt.");
                return View();
            }
        }

        public IActionResult Login()
        {
            return View(Input2);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> LoginFunction(LoginModelInput model)
        {
            if (ModelState.IsValid)
            {
                var result = await _applicationUserManager.LogIn(model.Login, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("MainView", "Platform", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

    }
}
