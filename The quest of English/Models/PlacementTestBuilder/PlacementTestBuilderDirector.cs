using The_quest_of_English.Models;

namespace The_quest_of_English
{
    public class PlacementTestBuilderDirector
    {
        private readonly PlacementTestBuilder _builder;
        private readonly AnswearAndQuestionsViewModel _model;
        public PlacementTestBuilderDirector(PlacementTestBuilder builder, AnswearAndQuestionsViewModel model)
        {
            _builder = builder;
            _model = model;
        }

        public PlacementTestTaskViewModel BuildTask()
        {
            _builder.AddFirstPartOfQuestion(_model.Question.QuestionFirstPart);
            _builder.AddMarkedPartOfQuestion(_model.Question.QuestionDecoratedPart);
            _builder.AddSecondPartOfQuestion(_model.Question.QuestionSecondPart);
            _builder.AddFirstAnswear(_model.Answear.FirstAnswear);
            _builder.AddSecondAnswear(_model.Answear.SecondAnswear);
            _builder.AddThirdAnswear(_model.Answear.ThirdAnswear);
            _builder.AddFourthAnswear(_model.Answear.FourthAnswear);
            _builder.AddCorrectAnswear(_model.Answear.CorrectAnswear);
            
            PlacementTestTaskViewModel task = new PlacementTestTaskViewModel();
            task = _builder.BuildQuestion();
            return task;
        }
    }
}
