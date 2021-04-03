using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using The_quest_of_English.ViewModelMapper;
using TheEnglishQuestCore;
using TheEnglishQuestCore.Managers;

namespace The_quest_of_English
{
    [Area("Admin")]
    public class ReadingController : Controller
    {
        private readonly ReadingQuizViewModelMapper _readingQuizViewModelMapper;
        private readonly ReadingQuizManager _readingQuizManager;
        private readonly ApplicationUserViewModelMapper _applicationUserViewModelMapper;
        private readonly ApplicationUserManager _applicationUserManager;
        private readonly ReadingTaskManager _readingTaskManager;
        private readonly ReadingTaskViewModelMapper _readingTaskViewModelMapper;


        public ReadingController(ReadingQuizViewModelMapper gvmm, ReadingQuizManager gq,
            ApplicationUserViewModelMapper uservmm, ApplicationUserManager usermanager,
            ReadingTaskManager grammarTaskManager, ReadingTaskViewModelMapper grammarTaskViewModelMapper)
        {
            _applicationUserViewModelMapper = uservmm;
            _applicationUserManager = usermanager;
            _readingQuizManager = gq;
            _readingQuizViewModelMapper = gvmm;
            _readingTaskManager = grammarTaskManager;
            _readingTaskViewModelMapper = grammarTaskViewModelMapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> FCE()
        {
            var QuizesList = await _readingQuizManager.GetAllQuizzesFiltered(SD.FCE);
            var QuizzesViewModel = _readingQuizViewModelMapper.Map(QuizesList);
            return View(QuizzesViewModel);
        }
        public async Task<IActionResult> CAE()
        {

            var QuizesList = await _readingQuizManager.GetAllQuizzesFiltered(SD.CAE);
            var QuizzesViewModel = _readingQuizViewModelMapper.Map(QuizesList);
            return View(QuizzesViewModel);
        }
        public async Task<IActionResult> CPE()
        {
            var QuizesList = await _readingQuizManager.GetAllQuizzesFiltered(SD.CPE);
            var QuizzesViewModel = _readingQuizViewModelMapper.Map(QuizesList);
            return View(QuizzesViewModel);
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
                var quizes = await _readingQuizManager.GetAllQuizzes();
                var quizesVM = _readingQuizViewModelMapper.Map(quizes);
                foreach (var item in quizesVM)
                {
                    if (item.Name == quiz.Name)
                    {
                        ModelState.AddModelError("Name", "There already is a quiz named like that!");
                        return View("GrammarCreateQuiz");
                    }
                    //Else there is no name like that -- continue.
                }
                //
                var userId = User.Identity.GetUserId();
                var quizDto = _readingQuizViewModelMapper.Map(quiz);
                await _readingQuizManager.AddNewQuiz(quizDto, userId);
                await _readingQuizManager.RemoveQuiz(quizDto);
                //Getting Quiz from DB with assigned Id
                var quizVM = await _readingQuizManager.FindQuizByName(quiz.Name);
                return RedirectToAction("ShowQuiz", new { quizId = quizVM.Id }); //Name of variable must be inside annonymus obj!
            }
            else
            {
                return RedirectToAction("CAE");
            }
        }

        public async Task<IActionResult> GrammarModifyQuiz(string level)
        {
            var QuizesList = await _readingQuizManager.GetAllQuizzesFiltered(level);
            var QuizzesViewModel = _readingQuizViewModelMapper.Map(QuizesList);
            return View(QuizzesViewModel);
        }

        public async Task<IActionResult> ModifySpecifiedQuiz(int id)
        {
            var Quizes = await _readingQuizManager.GetAllQuizzes();
            var Quiz = Quizes.Where(x => x.Id == id).SingleOrDefault();
            var QuizVm = _readingQuizViewModelMapper.Map(Quiz);
            return View(QuizVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModifySpecifiedQuiz(GrammarQuizViewModel quiz)
        {
            var QuizDto = _readingQuizViewModelMapper.Map(quiz);
            await _readingQuizManager.ModifyQuiz(QuizDto);
            return RedirectToAction(quiz.Level);
        }

        public async Task<IActionResult> GrammarDeleteQuiz(string level)
        {
            var QuizesList = await _readingQuizManager.GetAllQuizzesFiltered(level);
            var QuizzesViewModel = _readingQuizViewModelMapper.Map(QuizesList);
            return View(QuizzesViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GrammarDeleteQuiz(int id)
        {
            var Quiz = await _readingQuizManager.GetAllQuizzes();
            var ActualQuiz = Quiz.Where(x => x.Id == id).SingleOrDefault();
            string level = ActualQuiz.Level;
            await _readingQuizManager.RemoveQuiz(ActualQuiz);
            return RedirectToAction(level);
        }


        /// <summary>
        /// Those methods above are strictly related to all of quizzes functionalities.
        /// </summary>

        public async Task<IActionResult> ShowQuiz(int quizId)
        {
            //Get User
            var quiz = await _readingQuizManager.FindQuiz(quizId);
            var quizVM = _readingQuizViewModelMapper.Map(quiz);
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

        //TASKS SECTION

        public IActionResult CreateTask(int quizId)
        {
            GrammarTasksViewModel task = new GrammarTasksViewModel();
            task.GrammarQuizId = quizId;
            return View(task);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("CreateTask")]
        public IActionResult CreateTaskPost(GrammarTasksViewModel task)
        {
            return RedirectToAction("BuildTaskQuestionAndAnswear", new { ChosenType = task.TaskType, QuizId = task.GrammarQuizId });
        }


        public IActionResult BuildTaskQuestionAndAnswear(string ChosenType, int quizId)
        {
            GrammarTasksViewModel task = new GrammarTasksViewModel
            {
                GrammarQuizId = quizId,
                TaskType = ChosenType
            };
            return View(task);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("BuildTaskQuestionAndAnswear")]
        public async Task<IActionResult> BuildTaskQuestionAndAnswearPost(GrammarTasksViewModel task)
        {
            var taskDto = _readingTaskViewModelMapper.Map(task);
            await _readingTaskManager.AddNew(taskDto);
            return RedirectToAction("ShowQuiz", new { quizId = task.GrammarQuizId });
        }
        public async Task<IActionResult> ModifyTask(int quizId)
        {
            var SelectedQuiz = await _readingQuizManager.FindQuiz(quizId);
            var Tasks = SelectedQuiz.GrammarTasks;
            var TasksVm = _readingQuizViewModelMapper.Map(Tasks);
            return View(TasksVm);
        }

        public async Task<IActionResult> ModifySpecifiedTask(int taskId)
        {
            var SelectedTask = await _readingTaskManager.FindTask(taskId);
            var TaskVm = _readingTaskViewModelMapper.Map(SelectedTask);
            return View(TaskVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("ModifySpecifiedTask")]
        public async Task<IActionResult> ModifySpecifiedTaskPost(GrammarTasksViewModel task)
        {
            var taskDto = _readingTaskViewModelMapper.Map(task);
            await _readingTaskManager.ModifyTask(taskDto);
            return RedirectToAction("ShowQuiz", new { quizId = task.GrammarQuizId });
        }

        public async Task<IActionResult> DeleteTask(int quizId)
        {
            var SelectedQuiz = await _readingQuizManager.FindQuiz(quizId);
            var Tasks = SelectedQuiz.GrammarTasks;
            var TasksVm = _readingQuizViewModelMapper.Map(Tasks);
            return View(TasksVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteTask")]
        public async Task<IActionResult> DeleteTaskPost(int taskId)
        {
            var Entity = await _readingTaskManager.FindTask(taskId);
            int quizId = Entity.GrammarQuizId;
            await _readingTaskManager.Delete(Entity);
            return RedirectToAction("ShowQuiz", new { quizId = quizId });
        }
    }
}
