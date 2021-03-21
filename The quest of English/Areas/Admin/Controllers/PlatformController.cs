using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheEnglishQuestCore.Managers;
using Microsoft.AspNet.Identity;
using TheEnglishQuest;

namespace The_quest_of_English.Areas.Controllers
{
    [Area("Admin")]
    public class PlatformController : Controller
    {
        private readonly ApplicationUserViewModelMapper _applicationUserViewModelMapper;
        private readonly ApplicationUserManager _applicationUserManager;
        public PlatformController(ApplicationUserViewModelMapper applicationUserViewModelMapper, ApplicationUserManager applicationUserManager)
        {
            _applicationUserViewModelMapper = applicationUserViewModelMapper;
            _applicationUserManager = applicationUserManager;
        }

        public IActionResult MainView(ApplicationUserViewModel user)
        {
            return View(user);
        }
        public async Task<IActionResult> PlacementTest()
        {
            var userId = User.Identity.GetUserId();
            var user = await _applicationUserManager.GetLoggedUser(userId);
            var userViewModel = _applicationUserViewModelMapper.Map(user);
            return View(userViewModel);
        }
    }
}
