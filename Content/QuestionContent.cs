using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.INPC;
using WpfApp1.ViewModels;

namespace WpfApp1.Content
{
    public class QuestionsContent : BaseContent
    {
        private QuestionViewModel[] questions;
        private QuestionViewModel currentQuestion;
        private int currentQuestionIndex;
        private RelayCommand jumpQuestionCommand;

        public QuestionViewModel[] Questions { get => questions; set { questions = value; OnPropertyChanged(); currentQuestionIndex = -1; JumpQuestionMethod(1); } }
        public QuestionViewModel CurrentQuestion { get => currentQuestion; set { currentQuestion = value; OnPropertyChanged(); } }

        /// <summary>Индекс текущего вопроса</summary>
        private int CurrQuestionIndex { get => currentQuestionIndex; set { currentQuestionIndex = value; OnPropertyChanged(); } }
        public QuestionsContent(ExecuteHandler execute, CanExecuteHandler canExecute = null)
            : base(execute, canExecute) { }
        public RelayCommand JumpQuestionCommand => jumpQuestionCommand ?? (jumpQuestionCommand = new RelayCommand(JumpQuestionMethod, JumpQuestionCanMethod));
        private bool JumpQuestionCanMethod(object parameter)
        => parameter != null
           && int.TryParse(parameter.ToString(), out int parInt)
           && currentQuestionIndex + parInt >= 0 && currentQuestionIndex + parInt<Questions.Length;

        /// <summary>Метод перехода на вопрос с указанным смещением</summary>
        /// <param name="parameter">Смешение на следующий вопрос</param>
        private void JumpQuestionMethod(object parameter)
        {
            int newIndex = currentQuestionIndex + int.Parse(parameter.ToString());
            if (newIndex != currentQuestionIndex)
            {
                currentQuestionIndex = newIndex;
                CurrentQuestion = Questions[currentQuestionIndex];
            }
        }

    }
}
