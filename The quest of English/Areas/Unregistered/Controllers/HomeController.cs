using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using The_quest_of_English.Models;
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
            //Add
            SampleTestQAViewModel vm = new SampleTestQAViewModel()
            {
                Question = "The prevailing notion that wind power is too costly results largely from early research which focused on turbines with huge blades that stood hundreds of metres tall. These machines were not designed for ease of production or maintenance, and they were enormously expensive.",
                Question2 = "",
                QuestionDecorationPart = "",
                FirstQuestionRadioName = "ReadingAnswear5",
                FirstQuestionId = "ReadingAnswear13",
                FirstQuestionAnswear = "Wind power generates not enough money to be profitable.",
                SecondQuestionRadioName = "ReadingAnswear5",
                SecondQuestionId = "ReadingAnswear14",
                SecondQuestionAnswear = "The structure of machines is far too complicated.",
                ThirdQuestionRadioName = "ReadingAnswear5",
                ThirdQuestionId = "ReadingAnswear15",
                ThirdQuestionAnswear = "It is widely known that wind power is the best source of cheap energy.",
                Answear = "The structure of machines is far too complicated."
            };
            var entity = _SampleTestQAViewModelMapper.Map(vm);
            await _SampleTestQAManager.AddNew(entity);

            //var allEntities = await _SampleTestQAManager.GetAllValues();
            //var deletedObj = allEntities.Where(x => x.Id == 9).SingleOrDefault();
            //await _SampleTestQAManager.Delete(deletedObj);
            ///
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
