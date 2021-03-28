using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_quest_of_English.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReadingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FCE()
        {
            return View();
        }
        public IActionResult CAE()
        {
            return View();
        }
        public IActionResult CPE()
        {
            return View();
        }
    }
}
