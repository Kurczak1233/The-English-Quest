using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_quest_of_English.Models;

namespace The_quest_of_English.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GrammarController : Controller
    {
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

        public IActionResult GrammarCreateQuiz()
        {
            GrammarQuizViewModel quiz = new GrammarQuizViewModel();
            return View(quiz);
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
