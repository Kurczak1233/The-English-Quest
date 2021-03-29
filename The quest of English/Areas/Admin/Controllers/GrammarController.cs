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

        public IActionResult CreateLesson()
        {
            GrammarLesson lesson = new GrammarLesson();
            return View(lesson);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("CreateLesson")]
        public async Task<IActionResult> CreateLessonPost(GrammarLesson lesson)
        {
            return View();
        }
        public IActionResult ModifyLesson()
        {
            return View();
        }
        public IActionResult DeleteLesson()
        {
            return View();
        }

        public IActionResult CreateQuiz()
        {
            return View();
        }
        public IActionResult ModifyQuiz()
        {
            return View();
        }
        public IActionResult DeleteQuiz()
        {
            return View();
        }

    }
}
