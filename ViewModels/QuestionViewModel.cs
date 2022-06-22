using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.INPC;
using WpfApp1.TestClasses;

namespace WpfApp1.ViewModels
{
    public class QuestionViewModel : OnPropertyChangedBaseImplementation
    {
        protected static readonly Random rand = new Random();
        protected readonly TestQuestion TestQuestion;
        public AnswerViewModel[] Answers { get; }
        public QuestionViewModel(TestQuestion testQuestion)
        {
            TestQuestion = testQuestion;
            Answers = TestQuestion.Answers.Select(ans => new AnswerViewModel(ans))
                .OrderBy(x => rand.Next()).ToArray();
        }
        public string Text => TestQuestion.QuestionText;
        public bool Value => Answers.All(ans => ans.Value);
        public static QuestionViewModel Create(TestQuestion testQuestion)
        {
            return new QuestionRadioButtonViewModel(testQuestion);
        }
    }
}
