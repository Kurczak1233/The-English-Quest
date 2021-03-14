using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using The_quest_of_English.Models;
using The_quest_of_English.Models.ViewModels;
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
        private readonly SampleTestQAManager _SampleTestQAManager;
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
            //SampleTestQAViewModel vm = new SampleTestQAViewModel()
            //{
            //    Question = "Is the following word correct?",
            //    Question2 = "",
            //    QuestionDecorationPart = "Explainatory",
            //    FirstQuestionRadioName = "WritingAnswear5",
            //    FirstQuestionId = "WritingAnswear13",
            //    FirstQuestionAnswear = "Yes, it is.",
            //    SecondQuestionRadioName = "WritingAnswear5",
            //    SecondQuestionId = "WritingAnswear14",
            //    SecondQuestionAnswear = "No, it should be spelled: Explanatory",
            //    ThirdQuestionRadioName = "WritingAnswear5",
            //    ThirdQuestionId = "WritingAnswear15",
            //    ThirdQuestionAnswear = "No, it should be spelled: Explainattory",
            //    Answear = "No, it should be spelled: Explanatory"
            //};
            //var entity = _SampleTestQAViewModelMapper.Map(vm);
            //await _SampleTestQAMaganer.AddNew(entity);

            //Delete
            //var allEntities = await _SampleTestQAMaganer.GetAllValues();
            //var deletedObj = allEntities.Where(x => x.Id == 21).SingleOrDefault();
            //await _SampleTestQAMaganer.Delete(deletedObj);
            //var deletedObj2 = allEntities.Where(x => x.Id == 6).SingleOrDefault();
            //await _SampleTestQAMaganer.Delete(deletedObj2);
            //var deletedObj3 = allEntities.Where(x => x.Id == 7).SingleOrDefault();
            //await _SampleTestQAMaganer.Delete(deletedObj3);

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
    }
}
