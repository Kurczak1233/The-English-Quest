using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheEnglishQuestCore.Managers;

namespace The_quest_of_English.Controllers
{
    [Area("Unregistered")]
    public class HomeController : Controller
    {


        public HomeController()
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> SampleEnglishTest()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
