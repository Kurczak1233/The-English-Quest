using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using The_quest_of_English.Models;
using TheEnglishQuestCore;
using TheQuestOfEnglishDatabase;

namespace The_quest_of_English.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ViewModelMapper _VMMapper;
        private readonly IDTOManager _DTOManager;
        public HomeController(ILogger<HomeController> logger , ViewModelMapper mapper, IDTOManager manager)
        {
            _logger = logger;
            _VMMapper = mapper;
            _DTOManager = manager;
        }

        public async Task<IActionResult> Index()
        {
            var positions = await _DTOManager.GetAllPositions();
            var entities = _VMMapper.Map(positions);
            //CurrentyAddedOne.
            //EncouragementPositionViewModel model = new EncouragementPositionViewModel()
            //{
            //    HtmlIdName = "seventhCollapse",
            //    Content = "After a while, you will be able to take some English tests. If you pass those, you will be able to work up your way to the top in your company.",
            //    ReferenceToCollapse = "linkCollapse7"


            //};
            //var dto = _VMMapper.Map(model);
            //await _DTOManager.AddNewPosition(dto);

            return View(entities);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
