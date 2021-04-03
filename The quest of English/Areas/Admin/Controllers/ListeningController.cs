using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TheEnglishQuestCore.Managers;

namespace The_quest_of_English.Areas
{
    [Area("Admin")]
    public class ListeningController : Controller
    {
        private readonly ListeningQuizViewModelMapper _listeningQuizViewModelMapper;
        private readonly ListeningQuizManager _listeningQuizManager;
        private readonly ApplicationUserViewModelMapper _applicationUserViewModelMapper;
        private readonly ApplicationUserManager _applicationUserManager;
        private readonly ListeningTaskManager _listeningTaskManager;
        private readonly ListeningTaskViewModelMapper _listeningTaskViewModelMapper;


        public ListeningController(ListeningQuizViewModelMapper gvmm, ListeningQuizManager gq,
            ApplicationUserViewModelMapper uservmm, ApplicationUserManager usermanager,
            ListeningTaskManager grammarTaskManager, ListeningTaskViewModelMapper grammarTaskViewModelMapper)
        {
            _applicationUserViewModelMapper = uservmm;
            _applicationUserManager = usermanager;
            _listeningQuizManager = gq;
            _listeningQuizViewModelMapper = gvmm;
            _listeningTaskManager = grammarTaskManager;
            _listeningTaskViewModelMapper = grammarTaskViewModelMapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> FCE()
        {
            var QuizesList = await _grammarQuizManager.GetAllQuizzesFiltered(SD.FCE);
            var QuizzesViewModel = _grammarQuizViewModelMapper.Map(QuizesList);
            return View(QuizzesViewModel);
        }
        public async Task<IActionResult> CAE()
        {

            var QuizesList = await _grammarQuizManager.GetAllQuizzesFiltered(SD.CAE);
            var QuizzesViewModel = _grammarQuizViewModelMapper.Map(QuizesList);
            return View(QuizzesViewModel);
        }
        public async Task<IActionResult> CPE()
        {
            var QuizesList = await _grammarQuizManager.GetAllQuizzesFiltered(SD.CPE);
            var QuizzesViewModel = _grammarQuizViewModelMapper.Map(QuizesList);
            return View(QuizzesViewModel);
        }

        public async Task<IActionResult> GrammarCreateQuiz()
        {
            ListeningQuizViewModel quiz = new ListeningQuizViewModel();
            var userId = User.Identity.GetUserId();
            var user = await _applicationUserManager.GetLoggedUser(userId);
            var userViewModel = _applicationUserViewModelMapper.Map(user);
            quiz.User = userViewModel;
            return View(quiz);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("GrammarCreateQuiz")]
        public async Task<IActionResult> GrammarCreateQuizPost(ListeningQuizViewModel quiz)
        {
            if (ModelState.IsValid)
            {
                var quizes = await _grammarQuizManager.GetAllQuizzes();
                var quizesVM = _grammarQuizViewModelMapper.Map(quizes);
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
                var quizDto = _grammarQuizViewModelMapper.Map(quiz);
                await _grammarQuizManager.AddNewQuiz(quizDto, userId);
                await _grammarQuizManager.RemoveQuiz(quizDto);
                //Getting Quiz from DB with assigned Id
                var quizVM = await _grammarQuizManager.FindQuizByName(quiz.Name);
                return RedirectToAction("ShowQuiz", new { quizId = quizVM.Id }); //Name of variable must be inside annonymus obj!
            }
            else
            {
                return RedirectToAction("CAE");
            }
        }

        public async Task<IActionResult> GrammarModifyQuiz(string level)
        {
            var QuizesList = await _grammarQuizManager.GetAllQuizzesFiltered(level);
            var QuizzesViewModel = _grammarQuizViewModelMapper.Map(QuizesList);
            return View(QuizzesViewModel);
        }

        public async Task<IActionResult> ModifySpecifiedQuiz(int id)
        {
            var Quizes = await _grammarQuizManager.GetAllQuizzes();
            var Quiz = Quizes.Where(x => x.Id == id).SingleOrDefault();
            var QuizVm = _grammarQuizViewModelMapper.Map(Quiz);
            return View(QuizVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModifySpecifiedQuiz(ListeningQuizViewModel quiz)
        {
            var QuizDto = _grammarQuizViewModelMapper.Map(quiz);
            await _grammarQuizManager.ModifyQuiz(QuizDto);
            return RedirectToAction(quiz.Level);
        }

        public async Task<IActionResult> GrammarDeleteQuiz(string level)
        {
            var QuizesList = await _grammarQuizManager.GetAllQuizzesFiltered(level);
            var QuizzesViewModel = _grammarQuizViewModelMapper.Map(QuizesList);
            return View(QuizzesViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GrammarDeleteQuiz(int id)
        {
            var Quiz = await _grammarQuizManager.GetAllQuizzes();
            var ActualQuiz = Quiz.Where(x => x.Id == id).SingleOrDefault();
            string level = ActualQuiz.Level;
            await _grammarQuizManager.RemoveQuiz(ActualQuiz);
            return RedirectToAction(level);
        }


        /// <summary>
        /// Those methods above are strictly related to all of quizzes functionalities.
        /// </summary>

        public async Task<IActionResult> ShowQuiz(int quizId)
        {
            //Get User
            var quiz = await _grammarQuizManager.FindQuiz(quizId);
            var quizVM = _grammarQuizViewModelMapper.Map(quiz);
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
            ListeningTasksViewModel task = new ListeningTasksViewModel();
            task.GrammarQuizId = quizId;
            return View(task);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("CreateTask")]
        public IActionResult CreateTaskPost(ListeningTasksViewModel task)
        {
            return RedirectToAction("BuildTaskQuestionAndAnswear", new { ChosenType = task.TaskType, QuizId = task.GrammarQuizId });
        }


        public IActionResult BuildTaskQuestionAndAnswear(string ChosenType, int quizId)
        {
            ListeningTasksViewModel task = new ListeningTasksViewModel
            {
                GrammarQuizId = quizId,
                TaskType = ChosenType
            };
            return View(task);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("BuildTaskQuestionAndAnswear")]
        public async Task<IActionResult> BuildTaskQuestionAndAnswearPost(ListeningTasksViewModel task)
        {
            var taskDto = _grammarTaskViewModelMapper.Map(task);
            await _grammarTaskManager.AddNew(taskDto);
            return RedirectToAction("ShowQuiz", new { quizId = task.GrammarQuizId });
        }
        public async Task<IActionResult> ModifyTask(int quizId)
        {
            var SelectedQuiz = await _grammarQuizManager.FindQuiz(quizId);
            var Tasks = SelectedQuiz.GrammarTasks;
            var TasksVm = _grammarQuizViewModelMapper.Map(Tasks);
            return View(TasksVm);
        }

        public async Task<IActionResult> ModifySpecifiedTask(int taskId)
        {
            var SelectedTask = await _grammarTaskManager.FindTask(taskId);
            var TaskVm = _grammarTaskViewModelMapper.Map(SelectedTask);
            return View(TaskVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("ModifySpecifiedTask")]
        public async Task<IActionResult> ModifySpecifiedTaskPost(ListeningTasksViewModel task)
        {
            var taskDto = _grammarTaskViewModelMapper.Map(task);
            await _grammarTaskManager.ModifyTask(taskDto);
            return RedirectToAction("ShowQuiz", new { quizId = task.GrammarQuizId });
        }

        public async Task<IActionResult> DeleteTask(int quizId)
        {
            var SelectedQuiz = await _grammarQuizManager.FindQuiz(quizId);
            var Tasks = SelectedQuiz.GrammarTasks;
            var TasksVm = _grammarQuizViewModelMapper.Map(Tasks);
            return View(TasksVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteTask")]
        public async Task<IActionResult> DeleteTaskPost(int taskId)
        {
            var Entity = await _grammarTaskManager.FindTask(taskId);
            int quizId = Entity.GrammarQuizId;
            await _grammarTaskManager.Delete(Entity);
            return RedirectToAction("ShowQuiz", new { quizId = quizId });
        }
    }
}
