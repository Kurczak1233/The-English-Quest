using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            GrammarTasksViewModel lesson = new GrammarTasksViewModel();
            return View(lesson);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("CreateLesson")]
        public async Task<IActionResult> GrammarCreateQuiz(GrammarTasksViewModel lesson)
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
