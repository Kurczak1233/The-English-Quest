using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_quest_of_English.Models.PlacementTestBuilder
{
    public class PlacementTestBuilder
    {
        private PlacementTestQuestion _question = new PlacementTestQuestion();
        public void AddFirstPartOfQuestion(string firstPart)
        {
            _question.QuestionFirstPart = firstPart;
        }
        public void AddMarkedPartOfQuestion(string decoratedPart)
        {
            _question.QuestionDecoratedPart = decoratedPart;
        }
        public void AddSecondPartOfQuestion(string secondPart)
        {
            _question.QuestionSecondPart = secondPart;
        }
        public void AddFirstAnswear(string answear)
        {
            _question.FirstAnswear = answear;
        }
        public void AddSecondAnswear(string answear)
        {
            _question.SecondAnswear = answear;
        }
        public void AddThirdAnswear(string answear)
        {
            _question.ThirdAnswear = answear;
        }
        public void AddFourthAnswear(string answear)
        {
            _question.FourthAnswear = answear;
        }
        public void AddCorrectAnswear(string answear)
        {
            _question.CorrectAnswear = answear;
        }
    }
}
