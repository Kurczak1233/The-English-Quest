using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TheEnglishQuest;
using TheEnglishQuestCore.Managers;

namespace The_quest_of_English.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationUserViewModelMapper _applicationUserViewModelMapper;
        private readonly ApplicationUserManager _applicationUserManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        //private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserController(ApplicationUserManager applicationUserManager,
            ApplicationUserViewModelMapper applicationUserViewModelMapper,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            
            RoleManager<IdentityRole> roleManager)
        {
            _applicationUserManager = applicationUserManager;
            _applicationUserViewModelMapper = applicationUserViewModelMapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _roleManager = roleManager;
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
                Login = ApplicaitonUserInput.Login,
                EmailAdress = ApplicaitonUserInput.EmailAdress,
                Password = ApplicaitonUserInput.Password
            };
            await _applicationUserManager.CreateAdminRole();
            await _applicationUserManager.CreateUserRole();
            var userDto = _applicationUserViewModelMapper.Map(user);
            await _applicationUserManager.AddUser(userDto, ApplicaitonUserInput.Password);
            await _applicationUserManager.LogIn(userDto);
            return RedirectToAction("Home", "Index");
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
