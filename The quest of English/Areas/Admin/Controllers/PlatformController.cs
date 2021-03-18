using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_quest_of_English.Areas.Controllers
{
    [Area("Admin")]
    public class PlatformController : Controller
    {
        public IActionResult MainView()
        {
            return View();
        }
    }
}
