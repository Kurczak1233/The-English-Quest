namespace The_quest_of_English.Models
{
    public class PlacementTestBuilder
    {
        private PlacementTestTaskViewModel _question = new PlacementTestTaskViewModel();
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
        public PlacementTestTaskViewModel BuildQuestion()
        {
            var Task = _question;
            ClearQuestion();
            return Task;
        }
        public PlacementTestTaskViewModel ClearQuestion() => _question = new PlacementTestTaskViewModel();
    }
}
