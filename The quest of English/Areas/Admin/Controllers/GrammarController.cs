using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_quest_of_English.Models;
using TheEnglishQuestCore;
using TheEnglishQuestCore.Managers;

namespace The_quest_of_English.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class GrammarController : Controller
    {
        private readonly GrammarQuizViewModelMapper _grammarQuizViewModelMapper;
        private readonly GrammarQuizManager _grammarQuizManager;
        private readonly ApplicationUserViewModelMapper _applicationUserViewModelMapper;
        private readonly ApplicationUserManager _applicationUserManager;

        public GrammarController(GrammarQuizViewModelMapper gvmm, GrammarQuizManager gq, ApplicationUserViewModelMapper uservmm, ApplicationUserManager usermanager)
        {
            _applicationUserViewModelMapper = uservmm;
            _applicationUserManager = usermanager;
            _grammarQuizManager = gq;
            _grammarQuizViewModelMapper = gvmm;
        }

        [BindProperty]
        public string SectionName { get; set; } = "Grammar";

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FCE()
        {
            return View("CAE", SectionName);
        }
        public IActionResult CAE()
        {
            return View("CAE", SectionName);
        }
        public IActionResult CPE()
        {
            return View("CAE", SectionName);
        }

        public async Task<IActionResult> GrammarCreateQuiz()
        {
            GrammarQuizViewModel quiz = new GrammarQuizViewModel();
            var userId = User.Identity.GetUserId();
            var user = await _applicationUserManager.GetLoggedUser(userId);
            var userViewModel = _applicationUserViewModelMapper.Map(user);
            quiz.User = userViewModel;
            return View(quiz);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("GrammarCreateQuiz")]
        public async Task<IActionResult> GrammarCreateQuizPost(GrammarQuizViewModel quiz)
        {
            if (ModelState.IsValid)
            {
                var quizes = await _grammarQuizManager.GetAllQuizzes();
                var quizesVM = _grammarQuizViewModelMapper.Map(quizes);
                foreach(var item in quizesVM)
                {
                    if(item.Name == quiz.Name)
                    {
                        ModelState.AddModelError("Name", "There already is a quiz named like that!");
                        return View("GrammarCreateQuiz");
                    }
                    //Else there is no name like that -- continue.
                }
                //
                var userId = User.Identity.GetUserId();
                var user = await _applicationUserManager.GetLoggedUser(userId);
                var userVm = _applicationUserViewModelMapper.Map(user);
                var quizDto =  _grammarQuizViewModelMapper.Map(quiz);
                quizDto.User = user;
                await _grammarQuizManager.AddNewQuiz(quizDto, userId);
                //Getting Quiz from DB with assigned Id
                var quizVM = await _grammarQuizManager.FindQuizByName(quiz.Name);
                var quizEntity = _grammarQuizViewModelMapper.Map(quizVM);
                return RedirectToAction("ShowQuiz", new { quizId = quizEntity.Id }); //Name of variable must be here!
            }
            else
            {
                return RedirectToAction("CAE");
            }
        }
        public async Task<IActionResult> ShowQuiz(int quizId)
        {
            //Get Task
            var quizDto = await _grammarQuizManager.FindQuiz(quizId);
            var quizVM = _grammarQuizViewModelMapper.Map(quizDto);
            //Get User
            var userId = User.Identity.GetUserId();
            var user = await _applicationUserManager.GetLoggedUser(userId);
            var userVm = _applicationUserViewModelMapper.Map(user);
            QuizModelAndUserViewModel model = new QuizModelAndUserViewModel()
            {
                Quiz = quizVM,
                ApplicationUser = userVm,
            };
            return View(model); 
        }

        public IActionResult GrammarCreateTask()
        {
            GrammarTasksViewModel task = new GrammarTasksViewModel();
            return View(task);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("GrammarCreateTask")]
        public async Task<IActionResult> GrammarCreateTaskPost(GrammarTasksViewModel task)
        {
                return View();
        }
        public IActionResult GrammarModifyQuiz()
        {
            return View();
        }
        public IActionResult GrammarDeleteQuiz()
        {
            return View();
        }

    }
}
