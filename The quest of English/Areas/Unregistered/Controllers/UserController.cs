using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public UserController(ApplicationUserManager applicationUserManager,
            ApplicationUserViewModelMapper applicationUserViewModelMapper
            )
        {
            _applicationUserManager = applicationUserManager;
            _applicationUserViewModelMapper = applicationUserViewModelMapper;
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
                    ModelState.AddModelError("Email", "Invalid register attempt.");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("Email", "Model is not valid!");
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
                    var userId = User.Identity.GetUserId();
                    var user = await _applicationUserManager.GetLoggedUser(userId);
                    var userViewModel = _applicationUserViewModelMapper.Map(user);
                    return RedirectToAction("MainView", "Platform", new { area = "Admin", user=userViewModel });
                }
                else
                {
                    ModelState.AddModelError("Login", "Password or login is incorrect!");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("Login", "Password or login is incorrect!");
                return View();
            }
        }

    }
}
