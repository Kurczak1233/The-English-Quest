using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_quest_of_English.Models.ViewModels
{
    public class AnswearsAndQuestionsList
    {
        public IEnumerable<string> Answears{ get; set; }
        public IEnumerable<SampleTestQAViewModel> SampleTestQAViewModels { get; set; }
    }
}
