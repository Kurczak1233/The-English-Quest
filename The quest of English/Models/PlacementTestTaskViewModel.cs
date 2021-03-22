using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_quest_of_English.Models
{
    public class PlacementTestTaskViewModel
    {
        public int Id { get; set; }
        public string QuestionFirstPart { get; set; }
        public string QuestionDecoratedPart { get; set; }
        public string QuestionSecondPart { get; set; }
        public string FirstAnswear { get; set; }
        public string SecondAnswear { get; set; }
        public string ThirdAnswear { get; set; }
        public string FourthAnswear { get; set; }
        public string CorrectAnswear { get; set; }
    }
}
