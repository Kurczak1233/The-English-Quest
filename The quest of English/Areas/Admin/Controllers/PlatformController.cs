using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using The_quest_of_English.Models.InputModels;
using TheEnglishQuest;
using TheEnglishQuestCore.Managers;

namespace The_quest_of_English
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
        
        public QuestionModelInput QuestionModelInput { get; set; }
        public AnswearsModelInput AnswearsModelInput { get; set; }

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

        public IActionResult CreateQuestion()
        {
            QuestionModelInput question = new QuestionModelInput();
            return View(question);
        }

        public IActionResult CreateAnswears()
        {
            AnswearsModelInput answears = new AnswearsModelInput();
            return View(answears);
        }

        public IActionResult BuildTask()
        {
            return View();
        }

        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //[ActionName("CreateQuestion")]
        //public async Task<IActionResult> CreateQuestion()
        //{
        //    PlacementTestBuilder builder = new PlacementTestBuilder();
        //    builder.
        //}
    }
}
