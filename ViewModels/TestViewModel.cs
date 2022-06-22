using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.INPC;
using WpfApp1.TestClasses;

namespace WpfApp1.ViewModels
{
    public class TestViewModel : OnPropertyChangedBaseImplementation
    {
        private static readonly Random rand = new Random();
        private readonly Test Test;
        public QuestionViewModel[] Questions { get; }
        public TestViewModel(Test test)
        {
            Test = test;
            Questions = Test.Questions.Select(q => QuestionViewModel.Create(q))
                .OrderBy(x => rand.Next()).ToArray();
        }
        public string TestName => Test.TestName;
        public int RightCount() => Questions.Count(q => q.Value);
    }
}
