using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheEnglishQuestCore.Managers;

namespace The_quest_of_English.Controllers
{
    [Area("Unregistered")]
    public class HomeController : Controller
    {
        private readonly EncouragementPoisitonViewModelMapper _EPositionsMapper;
        private readonly EncouragementPostitionManager _EnouragementPositionManager;


        public HomeController(EncouragementPoisitonViewModelMapper eMapper,
            EncouragementPostitionManager eManager)
        {
            _EPositionsMapper = eMapper;
            _EnouragementPositionManager = eManager;
        }

        public async Task<IActionResult> Index()
        {
            var positions = await _EnouragementPositionManager.GetAllPositions();
            var entities = _EPositionsMapper.Map(positions);
            return View(entities);
        }

        public async Task<IActionResult> SampleEnglishTest()
        {

            //var AllListDto = await _SampleTestQAManager.GetAllValues();
            //var AnswearList = AllListDto.Select(x => x.Answear).ToList();
            //var dtos = await _SampleTestQAManager.GetAllValues();
            //var entities = _SampleTestQAViewModelMapper.Map(dtos);
            //AnswearsAndQuestionsList model = new AnswearsAndQuestionsList()
            //{
            //    Answears = AnswearList,
            //    SampleTestQAViewModels = entities.ToList()
            //};


            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
