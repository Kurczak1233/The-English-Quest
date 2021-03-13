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
            //Add
            //SampleTestQAViewModel vm = new SampleTestQAViewModel()
            //{
            //    Question = "In 1991, a ceasefire agreement was drawn up, in which a referendum on self-determination was promised to decide the fate of the country and its people.",
            //    Question2 = "",
            //    QuestionDecorationPart = "",
            //    FirstQuestionRadioName = "ReadingAnswear1",
            //    FirstQuestionId = "ReadingAnswear1",
            //    FirstQuestionAnswear = "There was a conflict",
            //    SecondQuestionRadioName = "ReadingAnswear1",
            //    SecondQuestionId = "ReadingAnswear2",
            //    SecondQuestionAnswear = "There was a debate",
            //    ThirdQuestionRadioName = "ReadingAnswear1",
            //    ThirdQuestionId = "ReadingAnswear3",
            //    ThirdQuestionAnswear = "There was a meeting",
            //    Answear = "There was a conflict"
            //};
            //var entity = _SampleTestQAViewModelMapper.Map(vm);
            //await _SampleTestQAMaganer.AddNew(entity);

            //Delete
            //var allEntities = await _SampleTestQAMaganer.GetAllValues();
            //var deletedObj = allEntities.Where(x => x.Id == 18).SingleOrDefault();
            //await _SampleTestQAMaganer.Delete(deletedObj);
            //var deletedObj2 = allEntities.Where(x => x.Id == 6).SingleOrDefault();
            //await _SampleTestQAMaganer.Delete(deletedObj2);
            //var deletedObj3 = allEntities.Where(x => x.Id == 7).SingleOrDefault();
            //await _SampleTestQAMaganer.Delete(deletedObj3);


            var dtos = await _SampleTestQAMaganer.GetAllValues();
            var entities = _SampleTestQAViewModelMapper.Map(dtos);
            return View(entities);
        }
    }
}
