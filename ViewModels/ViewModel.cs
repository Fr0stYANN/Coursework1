using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Content;
using WpfApp1.INPC;
using WpfApp1.Models;
using WpfApp1.TestClasses;

namespace WpfApp1.ViewModels
{
    public class ViewModel : OnPropertyChangedBaseImplementation
    {
        private readonly Test test;
        public string TestName => test.TestName;
        public TestViewModel TestView { get; private set; }
        private BaseContent _content;
        /// <summary>Контент ViewModel</summary>
        public BaseContent Content { get => _content; set { _content = value; OnPropertyChanged(); } }
        public ViewModel()
        {
            XmlDataProvider xmlDataProvider = new XmlDataProvider();
            test = xmlDataProvider.GetAllTests()[1];
            TotalMetod(null);
        }
        private void TitleMetod(object parameter)
        {
            Content = new QuestionsContent(QuestionsMetod) { Questions = TestView.Questions };
        }

        /// <summary>Метод для контента вопросов теста</summary>
        /// <param name="parameter">Не используется</param>
        private void QuestionsMetod(object parameter)
        {
            int CountRight = TestView.RightCount();
            Content = new TotalContent(TotalMetod)
            {
                CountRight = CountRight,
                CountTotal = TestView.Questions.Length
            };
            UserRepository userRepository = new UserRepository();
            userRepository.SetPoints(CountRight, DataBank.Login);
        }

        /// <summary>Метод для контента окончания теста</summary>
        /// <param name="parameter">Не используется</param>
        private void TotalMetod(object parameter)
        {
            TestView = new TestViewModel(test);
            Content = new TitleContent(TitleMetod) { TestName = TestView.TestName };
        }
    }
}
