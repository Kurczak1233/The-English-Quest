using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using The_quest_of_English.Models.ViewModels;
using TheEnglishQuestCore.Managers;

namespace The_quest_of_English.Controllers
{
    [Area("Unregistered")]
    public class HomeController : Controller
    {
        private readonly EncouragementPoisitonViewModelMapper _EPositionsMapper;
        private readonly EncouragementPostitionManager _EnouragementPositionManager;
        private readonly SampleTestQAViewModelMapper _SampleTestQAViewModelMapper;
        private readonly SampleTestQAManager _SampleTestQAManager;
        public HomeController(EncouragementPoisitonViewModelMapper eMapper,
            EncouragementPostitionManager eManager,
            SampleTestQAViewModelMapper sampletestmodel,
            SampleTestQAManager stQA)
        {
            _EPositionsMapper = eMapper;
            _EnouragementPositionManager = eManager;
            _SampleTestQAViewModelMapper = sampletestmodel;
            _SampleTestQAManager = stQA;
        }

        public async Task<IActionResult> Index()
        {
            var positions = await _EnouragementPositionManager.GetAllPositions();
            var entities = _EPositionsMapper.Map(positions);
            return View(entities);
        }

        public async Task<IActionResult> SampleEnglishTest()
        {
            var AllListDto = await _SampleTestQAManager.GetAllValues();
            var AnswearList = AllListDto.Select(x => x.Answear).ToList();
            var dtos = await _SampleTestQAManager.GetAllValues();
            var entities = _SampleTestQAViewModelMapper.Map(dtos);
            AnswearsAndQuestionsList model = new AnswearsAndQuestionsList()
            {
                Answears = AnswearList,
                SampleTestQAViewModels = entities.ToList()
            };


            return View(model);
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
