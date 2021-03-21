using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheEnglishQuestCore.Managers;
using Microsoft.AspNet.Identity;
using TheEnglishQuest;
using The_quest_of_English.Models;
using System.ComponentModel.DataAnnotations;

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
        
        public InputModel InputModelCreateQuestion { get; set; }
        public class InputModel
        {
            [Required]
            [StringLength(400, ErrorMessage = "The question can contain only 400 signs!")]
            public string QuestionFirstPart { get; set; }
            [StringLength(100, ErrorMessage = "The decoration part can contain only 100 signs!")]
            public string QuestionDecoratedPart { get; set; }
            [StringLength(400, ErrorMessage = "The question can contain only 400 signs!")]
            public string QuestionSecondPart { get; set; }

            [Required]
            [StringLength(200, ErrorMessage = "The answear can contain only 200 signs!")]
            public string FirstAnswear { get; set; }
            [Required]
            [StringLength(200, ErrorMessage = "The answear can contain only 200 signs!")]
            public string SecondAnswear { get; set; }
            [Required]
            [StringLength(200, ErrorMessage = "The answear can contain only 200 signs!")]
            public string ThirdAnswear { get; set; }
            [StringLength(200, ErrorMessage = "The answear can contain only 200 signs!")]
            public string FourthAnswear { get; set; }

            [Required]
            [StringLength(200, ErrorMessage = "The answear can contain only 200 signs!")]
            public string CorrectAnswear { get; set; }
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

        public IActionResult CreateQuestion()
        {
            PlacementTestQuestion question = new PlacementTestQuestion();
            return View(question);
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
