using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Content;
using WpfApp1.INPC;
using WpfApp1.TestClasses;
using WpfApp1.UserData;

namespace WpfApp1.ViewModels
{
    public class ViewModel : OnPropertyChangedBaseImplementation
    {
        private readonly Test test;
        public string TestName => test.TestName;
        public TestViewModel TestView { get; private set; }
        private BaseContent _content;
        public BaseContent Content { get => _content; set { _content = value; OnPropertyChanged(); } }
        public ViewModel(int testId)
        {
            XmlDataProvider xmlDataProvider = new XmlDataProvider();
            test = xmlDataProvider.GetAllTests().Where(test => test.TestId == testId).FirstOrDefault();
            TestIdContainer.TestMinutesLimit = test.MinutesLimit;
            TotalMethod(null);
        }
        private void TitleMethod(object parameter)
        {
            Content = new QuestionsContent(QuestionsMethod, test.MinutesLimit) { Questions = TestView.Questions };
        }
        private void QuestionsMethod(object parameter)
        {
            int CountRight = TestView.RightCount();
            Content = new TotalContent(TotalMethod)
            {
                CountRight = CountRight,
                CountTotal = TestView.Questions.Length
            };
            AttemptRepository attemptRepository = new AttemptRepository();
            attemptRepository.SetPointsToAttemptTable(DataBank.Login, test.TestName, CountRight);
        }
        private void TotalMethod(object parameter)
        {
            TestView = new TestViewModel(test);
            Content = new TitleContent(TitleMethod) { TestName = TestView.TestName };
        }
    }
}
