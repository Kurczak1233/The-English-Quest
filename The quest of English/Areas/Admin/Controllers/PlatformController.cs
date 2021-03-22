using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using The_quest_of_English.Models;
using The_quest_of_English.Models.ViewModels;
using The_quest_of_English.ViewModelMapper;
using TheEnglishQuest;
using TheEnglishQuestCore;
using TheEnglishQuestCore.Managers;

namespace The_quest_of_English
{
    [Area("Admin")]
    public class PlatformController : Controller
    {
        private readonly ApplicationUserViewModelMapper _applicationUserViewModelMapper;
        private readonly ApplicationUserManager _applicationUserManager;
        private readonly PlacementTestTaskViewModelMapper _placementTestTaskViewModelMapper;
        private readonly PlacementTestTaskManager _placementTestTaskManager;

        public int MyProperty { get; set; }
        public PlatformController(ApplicationUserViewModelMapper applicationUserViewModelMapper, ApplicationUserManager applicationUserManager, PlacementTestTaskViewModelMapper placementTestTaskViewModelMapper, PlacementTestTaskManager placementTestTaskManager)
        {
            _applicationUserViewModelMapper = applicationUserViewModelMapper;
            _applicationUserManager = applicationUserManager;
            _placementTestTaskViewModelMapper = placementTestTaskViewModelMapper;
            _placementTestTaskManager = placementTestTaskManager;
        }
        public async Task<IActionResult> MainView()
        {
            var userId = User.Identity.GetUserId();
            var user = await _applicationUserManager.GetLoggedUser(userId);
            var userViewModel = _applicationUserViewModelMapper.Map(user);
            return View(userViewModel);
        }
        public async Task<IActionResult> PlacementTest()
        {
            var TasksListDto = await _placementTestTaskManager.GetAllPositions();
            var TaskList = _placementTestTaskViewModelMapper.Map(TasksListDto);
            return View(TaskList);
        }

        public IActionResult CreateQuestion()
        {
            QuestionModelInput question = new QuestionModelInput();
            return View(question);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        [ActionName("CreateQuestion")]
        public IActionResult CreateQuestions(QuestionModelInput questions)
        {
            AnswearAndQuestionsViewModel viewModel = new AnswearAndQuestionsViewModel();
            viewModel.Question = questions;
            return View("CreateAnswears", viewModel);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreateAnswearsFunction(AnswearAndQuestionsViewModel questionsAndAnswears)
        {
            PlacementTestBuilder builder = new PlacementTestBuilder();
            PlacementTestBuilderDirector director = new PlacementTestBuilderDirector(builder, questionsAndAnswears);
            PlacementTestTaskViewModel model = new PlacementTestTaskViewModel(); 
            model = director.BuildTask();
            var modelDto = _placementTestTaskViewModelMapper.Map(model);
            await _placementTestTaskManager.AddNewPosition(modelDto);
            return RedirectToAction("PlacementTest");
        }

        public IActionResult BuildTask()
        {
            return View();
        }
    }
}
