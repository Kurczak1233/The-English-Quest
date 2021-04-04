using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_quest_of_English.ViewModelMapper;
using TheEnglishQuestCore;
using TheEnglishQuestCore.Managers;

namespace The_quest_of_English.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpeakingController : Controller
    {
        private readonly SpeakingQuizViewModelMapper _SpeakingQuizViewModelMapper;
        private readonly SpeakingQuizManager _SpeakingQuizManager;
        private readonly ApplicationUserViewModelMapper _applicationUserViewModelMapper;
        private readonly ApplicationUserManager _applicationUserManager;
        private readonly SpeakingTaskManager _SpeakingTaskManager;
        private readonly SpeakingTaskViewModelMapper _SpeakingTaskViewModelMapper;


        public SpeakingController(SpeakingQuizViewModelMapper gvmm, SpeakingQuizManager gq,
            ApplicationUserViewModelMapper uservmm, ApplicationUserManager usermanager,
            SpeakingTaskManager speakingTaskManager, SpeakingTaskViewModelMapper speakingTaskViewModelMapper)
        {
            _applicationUserViewModelMapper = uservmm;
            _applicationUserManager = usermanager;
            _SpeakingQuizManager = gq;
            _SpeakingQuizViewModelMapper = gvmm;
            _SpeakingTaskManager = speakingTaskManager;
            _SpeakingTaskViewModelMapper = speakingTaskViewModelMapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AllLevels()
        {
            var QuizesList = await _SpeakingQuizManager.GetAllQuizzes();
            var QuizzesViewModel = _SpeakingQuizViewModelMapper.Map(QuizesList);
            return View(QuizzesViewModel);
        }

        public async Task<IActionResult> SpeakingCreateQuiz()
        {
            SpeakingQuizViewModel quiz = new SpeakingQuizViewModel();
            var userId = User.Identity.GetUserId();
            var user = await _applicationUserManager.GetLoggedUser(userId);
            var userViewModel = _applicationUserViewModelMapper.Map(user);
            quiz.User = userViewModel;
            return View(quiz);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("SpeakingCreateQuiz")]
        public async Task<IActionResult> SpeakingCreateQuizPost(SpeakingQuizViewModel quiz)
        {
            if (ModelState.IsValid)
            {
                var quizes = await _SpeakingQuizManager.GetAllQuizzes();
                var quizesVM = _SpeakingQuizViewModelMapper.Map(quizes);
                foreach (var item in quizesVM)
                {
                    if (item.Name == quiz.Name)
                    {
                        ModelState.AddModelError("Name", "There already is a quiz named like that!");
                        return View("SpeakingCreateQuiz");
                    }
                    //Else there is no name like that -- continue.
                }
                //
                var userId = User.Identity.GetUserId();
                var quizDto = _SpeakingQuizViewModelMapper.Map(quiz);
                await _SpeakingQuizManager.AddNewQuiz(quizDto, userId);
                await _SpeakingQuizManager.RemoveQuiz(quizDto);
                //Getting Quiz from DB with assigned Id
                var quizVM = await _SpeakingQuizManager.FindQuizByName(quiz.Name);
                return RedirectToAction("ShowQuiz", new { quizId = quizVM.Id }); //Name of variable must be inside annonymus obj!
            }
            else
            {
                return RedirectToAction("AllLevels");
            }
        }

        public async Task<IActionResult> SpeakingModifyQuiz()
        {
            if (User.IsInRole(SD.OrdinaryUser))
            {
                var QuizesList = await _SpeakingQuizManager.GetAllQuizzes();
                var UsersQuizes = QuizesList.Where(x => x.UserId == User.Identity.GetUserId());
                var UsersQuizesViewModel = _SpeakingQuizViewModelMapper.Map(UsersQuizes);
                return View(UsersQuizesViewModel);
            }
            else
            {
                var QuizesList = await _SpeakingQuizManager.GetAllQuizzes();
                var QuizzesViewModel = _SpeakingQuizViewModelMapper.Map(QuizesList);
                return View(QuizzesViewModel);
            }
        }

        public async Task<IActionResult> ModifySpecifiedQuiz(int id)
        {
            var Quizes = await _SpeakingQuizManager.GetAllQuizzes();
            var Quiz = Quizes.Where(x => x.Id == id).SingleOrDefault();
            var QuizVm = _SpeakingQuizViewModelMapper.Map(Quiz);
            return View(QuizVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModifySpecifiedQuiz(SpeakingQuizViewModel quiz)
        {
            var QuizDto = _SpeakingQuizViewModelMapper.Map(quiz);
            await _SpeakingQuizManager.ModifyQuiz(QuizDto);
            return RedirectToAction("AllLevels");
        }

        public async Task<IActionResult> SpeakingDeleteQuiz()
        {
            if (User.IsInRole(SD.OrdinaryUser))
            {
                var QuizesList = await _SpeakingQuizManager.GetAllQuizzes();
                var UsersQuizes = QuizesList.Where(x => x.UserId == User.Identity.GetUserId());
                var UsersQuizesViewModel = _SpeakingQuizViewModelMapper.Map(UsersQuizes);
                return View(UsersQuizesViewModel);
            }
            else
            {
                var QuizesList = await _SpeakingQuizManager.GetAllQuizzes();
                var QuizzesViewModel = _SpeakingQuizViewModelMapper.Map(QuizesList);
                return View(QuizzesViewModel);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SpeakingDeleteQuiz(int id)
        {
            var Quiz = await _SpeakingQuizManager.GetAllQuizzes();
            var ActualQuiz = Quiz.Where(x => x.Id == id).SingleOrDefault();
            string level = ActualQuiz.Level;
            await _SpeakingQuizManager.RemoveQuiz(ActualQuiz);
            return RedirectToAction("AllLevels");
        }


        /// <summary>
        /// Those methods above are strictly related to all of quizzes functionalities.
        /// </summary>

        public async Task<IActionResult> ShowQuiz(int quizId)
        {
            //Get User
            var quiz = await _SpeakingQuizManager.FindQuiz(quizId);
            var quizVM = _SpeakingQuizViewModelMapper.Map(quiz);
            var userId = User.Identity.GetUserId();
            var user = await _applicationUserManager.GetLoggedUser(userId);
            var userVm = _applicationUserViewModelMapper.Map(user);
            QuizModelAndUserViewModelSpeaking model = new QuizModelAndUserViewModelSpeaking()
            {
                Quiz = quizVM,
                ApplicationUser = userVm,
            };
            return View(model);
        }

        //TASKS SECTION

        public IActionResult CreateTask(int quizId)
        {
            SpeakingTaskViewModel task = new SpeakingTaskViewModel();
            task.SpeakingQuizId = quizId;
            return View(task);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("CreateTask")]
        public IActionResult CreateTaskPost(SpeakingTaskViewModel task)
        {
            return RedirectToAction("BuildTaskQuestionAndAnswear", new { ChosenType = task.TaskType, QuizId = task.SpeakingQuizId });
        }


        public IActionResult BuildTaskQuestionAndAnswear(string ChosenType, int quizId)
        {
            SpeakingTaskViewModel task = new SpeakingTaskViewModel
            {
                SpeakingQuizId = quizId,
                TaskType = ChosenType
            };
            return View(task);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("BuildTaskQuestionAndAnswear")]
        public async Task<IActionResult> BuildTaskQuestionAndAnswearPost(SpeakingTaskViewModel task)
        {
            var taskDto = _SpeakingTaskViewModelMapper.Map(task);
            await _SpeakingTaskManager.AddNew(taskDto);
            return RedirectToAction("ShowQuiz", new { quizId = task.SpeakingQuizId });
        }
        public async Task<IActionResult> ModifyTask(int quizId)
        {
            var SelectedQuiz = await _SpeakingQuizManager.FindQuiz(quizId);
            var Tasks = SelectedQuiz.SpeakingTasks;
            var TasksVm = _SpeakingQuizViewModelMapper.Map(Tasks);
            return View(TasksVm);
        }

        public async Task<IActionResult> ModifySpecifiedTask(int taskId)
        {
            var SelectedTask = await _SpeakingTaskManager.FindTask(taskId);
            var TaskVm = _SpeakingTaskViewModelMapper.Map(SelectedTask);
            return View(TaskVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("ModifySpecifiedTask")]
        public async Task<IActionResult> ModifySpecifiedTaskPost(SpeakingTaskViewModel task)
        {
            var taskDto = _SpeakingTaskViewModelMapper.Map(task);
            await _SpeakingTaskManager.ModifyTask(taskDto);
            return RedirectToAction("ShowQuiz", new { quizId = task.SpeakingQuizId });
        }

        public async Task<IActionResult> DeleteTask(int quizId)
        {
            var SelectedQuiz = await _SpeakingQuizManager.FindQuiz(quizId);
            var Tasks = SelectedQuiz.SpeakingTasks;
            var TasksVm = _SpeakingQuizViewModelMapper.Map(Tasks);
            return View(TasksVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteTask")]
        public async Task<IActionResult> DeleteTaskPost(int taskId)
        {
            var Entity = await _SpeakingTaskManager.FindTask(taskId);
            int quizId = Entity.SpeakingQuizId;
            await _SpeakingTaskManager.Delete(Entity);
            return RedirectToAction("ShowQuiz", new { quizId = quizId });
        }
    }
}
