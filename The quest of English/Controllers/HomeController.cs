using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using The_quest_of_English.Models;
using TheEnglishQuestCore;
using TheEnglishQuestCore.Managers;
using TheEnglishQuestDatabase.Entities;
using TheQuestOfEnglishDatabase;

namespace The_quest_of_English.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //Żeby nie trzeba było wypisywać, wszystko do jednej klasy? Interefejsy?
        private readonly EncouragementPoisitonViewModelMapper _EPositionsMapper;
        private readonly ApplicationUserViewModelMapper _ApplicationUserMapper;
        private readonly ApplicationUserManager _ApplicationUserManager;
        private readonly EncouragementPostitionManager _EnouragementPositionManager;
        private readonly SampleTestQAViewModelMapper _SampleTestQAViewModelMapper;
        private readonly SampleTestQAManager _SampleTestQAMaganer;
        public HomeController(ILogger<HomeController> logger, EncouragementPoisitonViewModelMapper eMapper,
            ApplicationUserViewModelMapper aMapper, ApplicationUserManager aManager, EncouragementPostitionManager eManager
            , SampleTestQAViewModelMapper sampletestmodel, SampleTestQAManager stQA)
        {
            _logger = logger;
            _EPositionsMapper = eMapper;
            _EnouragementPositionManager = eManager;
            _ApplicationUserMapper = aMapper;
            _ApplicationUserManager = aManager;
            _SampleTestQAViewModelMapper = sampletestmodel;
            _SampleTestQAMaganer = stQA;
        }

        public async Task<IActionResult> Index()
        {
            var positions = await _EnouragementPositionManager.GetAllPositions();
            var entities = _EPositionsMapper.Map(positions);
            return View(entities);
        }

        public async Task<IActionResult> SampleEnglishTest()
        {
            //SampleTestQAViewModel vm = new SampleTestQAViewModel()
            //{
            //    Question = "Test",
            //    QuestionDecorationPart = "Test",
            //    FirstQuestionRadioName = "Test1",
            //    FirstQuestionId = "Test1",
            //    FirstQuestionAnswear = "Test1",
            //    SecondQuestionRadioName = "Test2",
            //    SecondQuestionId = "Test2",
            //    SecondQuestionAnswear = "Test2",
            //    ThirdQuestionRadioName = "Test3",
            //    ThirdQuestionId = "Test3",
            //    ThirdQuestionAnswear = "Test3"
            //};
            //var entity = _SampleTestQAViewModelMapper.Map(vm);
            //await _SampleTestQAMaganer.AddNew(entity);
            var ListOfEntities = await _SampleTestQAMaganer.GetAllValues();
            var entities = _SampleTestQAViewModelMapper.Map(ListOfEntities);
            return View(entities);
        }
    }
}
