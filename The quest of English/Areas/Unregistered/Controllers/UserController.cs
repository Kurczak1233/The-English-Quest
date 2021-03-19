using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        //private readonly IEmailSender _emailSender;
        public UserController(ApplicationUserManager applicationUserManager,
            ApplicationUserViewModelMapper applicationUserViewModelMapper,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger
            )
        {
            _applicationUserManager = applicationUserManager;
            _applicationUserViewModelMapper = applicationUserViewModelMapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        [BindProperty]
        public ApplicationUserViewModel ApplicaitonUserInput { get; set; }

        public IActionResult Register()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        [ActionName("Register")]
        public async Task<IActionResult> RegisterFunction()
        {
            ApplicationUserViewModel user = new ApplicationUserViewModel()
            {
                UserName = ApplicaitonUserInput.UserName,
                EmailAdress = ApplicaitonUserInput.EmailAdress,
                //Password = ApplicaitonUserInput.Password
            };
            var userDto = _applicationUserViewModelMapper.Map(user);
            var resultAdd = await _applicationUserManager.AddUser(userDto);
            if (resultAdd.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("MainView", "Platform", new { area = "Admin" });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid register attempt.");
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> LoginFunction()
        {
            if (ModelState.IsValid)
            {
                var result = await _applicationUserManager.LogIn(ApplicaitonUserInput.UserName, ApplicaitonUserInput.PhoneNumber);
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
