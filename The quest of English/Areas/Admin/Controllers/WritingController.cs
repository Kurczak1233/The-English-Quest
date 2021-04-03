using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TheEnglishQuestCore;
using TheEnglishQuestCore.Managers;

namespace The_quest_of_English
{
    [Area("Admin")]
    public class WritingController : Controller
    {
        private readonly WritingQuizViewModelMapper _writingQuizViewModelMapper;
        private readonly WritingQuizManager _writingQuizManager;
        private readonly ApplicationUserViewModelMapper _applicationUserViewModelMapper;
        private readonly ApplicationUserManager _applicationUserManager;
        private readonly WritingTaskManager _writingTaskManager;
        private readonly WritingTaskViewModelMapper _writingTaskViewModelMapper;


        public WritingController(WritingQuizViewModelMapper gvmm, WritingQuizManager gq,
            ApplicationUserViewModelMapper uservmm, ApplicationUserManager usermanager,
            WritingTaskManager writingTaskManager, WritingTaskViewModelMapper writingTaskViewModelMapper)
        {
            _applicationUserViewModelMapper = uservmm;
            _applicationUserManager = usermanager;
            _writingQuizManager = gq;
            _writingQuizViewModelMapper = gvmm;
            _writingTaskManager = writingTaskManager;
            _writingTaskViewModelMapper = writingTaskViewModelMapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AllLevels()
        {
            var QuizesList = await _writingQuizManager.GetAllQuizzes();
            var QuizzesViewModel = _writingQuizViewModelMapper.Map(QuizesList);
            return View(QuizzesViewModel);
        }

        public async Task<IActionResult> WritingCreateQuiz()
        {
            WritingQuizViewModel quiz = new WritingQuizViewModel();
            var userId = User.Identity.GetUserId();
            var user = await _applicationUserManager.GetLoggedUser(userId);
            var userViewModel = _applicationUserViewModelMapper.Map(user);
            quiz.User = userViewModel;
            return View(quiz);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("WritingCreateQuiz")]
        public async Task<IActionResult> WritingCreateQuizPost(WritingQuizViewModel quiz)
        {
            if (ModelState.IsValid)
            {
                var quizes = await _writingQuizManager.GetAllQuizzes();
                var quizesVM = _writingQuizViewModelMapper.Map(quizes);
                foreach (var item in quizesVM)
                {
                    if (item.Name == quiz.Name)
                    {
                        ModelState.AddModelError("Name", "There already is a quiz named like that!");
                        return View("WritingCreateQuiz");
                    }
                    //Else there is no name like that -- continue.
                }
                //
                var userId = User.Identity.GetUserId();
                var quizDto = _writingQuizViewModelMapper.Map(quiz);
                await _writingQuizManager.AddNewQuiz(quizDto, userId);
                await _writingQuizManager.RemoveQuiz(quizDto);
                //Getting Quiz from DB with assigned Id
                var quizVM = await _writingQuizManager.FindQuizByName(quiz.Name);
                return RedirectToAction("ShowQuiz", new { quizId = quizVM.Id }); //Name of variable must be inside annonymus obj!
            }
            else
            {
                return RedirectToAction("AllLevels");
            }
        }

        public async Task<IActionResult> WritingModifyQuiz()
        {
            var QuizesList = await _writingQuizManager.GetAllQuizzes();
            var QuizzesViewModel = _writingQuizViewModelMapper.Map(QuizesList);
            return View(QuizzesViewModel);
        }

        public async Task<IActionResult> ModifySpecifiedQuiz(int id)
        {
            var Quizes = await _writingQuizManager.GetAllQuizzes();
            var Quiz = Quizes.Where(x => x.Id == id).SingleOrDefault();
            var QuizVm = _writingQuizViewModelMapper.Map(Quiz);
            return View(QuizVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModifySpecifiedQuiz(WritingQuizViewModel quiz)
        {
            var QuizDto = _writingQuizViewModelMapper.Map(quiz);
            await _writingQuizManager.ModifyQuiz(QuizDto);
            return RedirectToAction("AllLevels");
        }

        public async Task<IActionResult> WritingDeleteQuiz()
        {
            var QuizesList = await _writingQuizManager.GetAllQuizzes();
            var QuizzesViewModel = _writingQuizViewModelMapper.Map(QuizesList);
            return View(QuizzesViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> WritingDeleteQuiz(int id)
        {
            var Quiz = await _writingQuizManager.GetAllQuizzes();
            var ActualQuiz = Quiz.Where(x => x.Id == id).SingleOrDefault();
            string level = ActualQuiz.Level;
            await _writingQuizManager.RemoveQuiz(ActualQuiz);
            return RedirectToAction("AllLevels");
        }


        /// <summary>
        /// Those methods above are strictly related to all of quizzes functionalities.
        /// </summary>

        public async Task<IActionResult> ShowQuiz(int quizId)
        {
            //Get User
            var quiz = await _writingQuizManager.FindQuiz(quizId);
            var quizVM = _writingQuizViewModelMapper.Map(quiz);
            var userId = User.Identity.GetUserId();
            var user = await _applicationUserManager.GetLoggedUser(userId);
            var userVm = _applicationUserViewModelMapper.Map(user);
            QuizModelAndUserViewModelWriting model = new QuizModelAndUserViewModelWriting()
            {
                Quiz = quizVM,
                ApplicationUser = userVm,
            };
            return View(model);
        }

        //TASKS SECTION

        public IActionResult CreateTask(int quizId)
        {
            WritingTaskViewModel task = new WritingTaskViewModel();
            task.WritingQuizId = quizId;
            return View(task);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("CreateTask")]
        public IActionResult CreateTaskPost(WritingTaskViewModel task)
        {
            return RedirectToAction("BuildTaskQuestionAndAnswear", new { ChosenType = task.TaskType, QuizId = task.WritingQuizId });
        }


        public IActionResult BuildTaskQuestionAndAnswear(string ChosenType, int quizId)
        {
            WritingTaskViewModel task = new WritingTaskViewModel
            {
                WritingQuizId = quizId,
                TaskType = ChosenType
            };
            return View(task);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("BuildTaskQuestionAndAnswear")]
        public async Task<IActionResult> BuildTaskQuestionAndAnswearPost(WritingTaskViewModel task)
        {
            var taskDto = _writingTaskViewModelMapper.Map(task);
            await _writingTaskManager.AddNew(taskDto);
            return RedirectToAction("ShowQuiz", new { quizId = task.WritingQuizId });
        }
        public async Task<IActionResult> ModifyTask(int quizId)
        {
            var SelectedQuiz = await _writingQuizManager.FindQuiz(quizId);
            var Tasks = SelectedQuiz.WritingTasks;
            var TasksVm = _writingQuizViewModelMapper.Map(Tasks);
            return View(TasksVm);
        }

        public async Task<IActionResult> ModifySpecifiedTask(int taskId)
        {
            var SelectedTask = await _writingTaskManager.FindTask(taskId);
            var TaskVm = _writingTaskViewModelMapper.Map(SelectedTask);
            return View(TaskVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("ModifySpecifiedTask")]
        public async Task<IActionResult> ModifySpecifiedTaskPost(WritingTaskViewModel task)
        {
            var taskDto = _writingTaskViewModelMapper.Map(task);
            await _writingTaskManager.ModifyTask(taskDto);
            return RedirectToAction("ShowQuiz", new { quizId = task.WritingQuizId });
        }

        public async Task<IActionResult> DeleteTask(int quizId)
        {
            var SelectedQuiz = await _writingQuizManager.FindQuiz(quizId);
            var Tasks = SelectedQuiz.WritingTasks;
            var TasksVm = _writingQuizViewModelMapper.Map(Tasks);
            return View(TasksVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteTask")]
        public async Task<IActionResult> DeleteTaskPost(int taskId)
        {
            var Entity = await _writingTaskManager.FindTask(taskId);
            int quizId = Entity.WritingQuizId;
            await _writingTaskManager.Delete(Entity);
            return RedirectToAction("ShowQuiz", new { quizId = quizId });
        }
    }
}
