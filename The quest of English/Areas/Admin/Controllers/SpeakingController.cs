using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_quest_of_English.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpeakingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
