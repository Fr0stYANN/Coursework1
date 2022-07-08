using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using WpfApp1.INPC;
using WpfApp1.ViewModels;

namespace WpfApp1.Content
{
    public class QuestionsContent : BaseContent
    {
        private QuestionViewModel[] questions;
        private QuestionViewModel currentQuestion;
        private int currentQuestionIndex;
        public int currentQuestionIndexToShow;
        private RelayCommand jumpQuestionCommand;
        private int seconds = 0;
        private int minutes = 0;
        private string timerString;
        private bool isEnabled = true;
        DispatcherTimer timer = new DispatcherTimer();
        public string MinutesLimitToShow { get; set; }
        public bool IsEnabled { get => isEnabled; set { isEnabled = value; OnPropertyChanged(); } }
        public string TimerString { get => timerString; set { timerString = value; OnPropertyChanged(); } }
        public int Seconds { get => seconds; set { seconds = value; OnPropertyChanged(); } }
        public int Minutes { get => minutes; set { minutes = value; OnPropertyChanged(); } }
        public QuestionViewModel[] Questions { get => questions; set { questions = value; OnPropertyChanged(); currentQuestionIndex = -1; JumpQuestionMethod(1); } }
        public QuestionViewModel CurrentQuestion { get => currentQuestion; set { currentQuestion = value; OnPropertyChanged(); } }
        public int MinutesLimit { get; set; }
        public int CurrQuestionIndex { get => currentQuestionIndex; set { currentQuestionIndex = value; OnPropertyChanged(); } }
        public int CurrentQuestionIndexToShow { get => currentQuestionIndexToShow; set { currentQuestionIndexToShow = value; OnPropertyChanged(); } }
        public QuestionsContent(ExecuteHandler execute,int MinutesLimit,CanExecuteHandler canExecute = null)
            : base(execute, canExecute)
        {
            this.MinutesLimit = MinutesLimit;
            MinutesLimitToShow = $"Для проходження тесту ви маєте {MinutesLimit} хвилин(и)";
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if(Minutes >= MinutesLimit)
            {
                Seconds++;
                IsEnabled = false;
                if(minutes > 10)
                {
                    TimerString = $"{minutes}:00";
                }
                else
                {
                    TimerString = $"0{minutes}:00";
                }
                timer.Stop();
                return;
            }
            if (Seconds >= 59)
            {
                Minutes = 0;
                Minutes++;
            }
            else
            {
                Seconds++;
            }
            if (Seconds < 10)
            {
                TimerString = $"0{Minutes}:0{Seconds}";
            }
            else
            {
                TimerString = $"0{Minutes}:{Seconds}";
            }
        }
        public RelayCommand JumpQuestionCommand => jumpQuestionCommand ?? (jumpQuestionCommand = new RelayCommand(JumpQuestionMethod, JumpQuestionCanMethod));
        private bool JumpQuestionCanMethod(object parameter)
        => parameter != null
           && int.TryParse(parameter.ToString(), out int parInt)
           && currentQuestionIndex + parInt >= 0 && currentQuestionIndex + parInt<Questions.Length;

        private void JumpQuestionMethod(object parameter)
        {
            int newIndex = currentQuestionIndex + int.Parse(parameter.ToString());
            if (newIndex != currentQuestionIndex)
            {
                currentQuestionIndex = newIndex;
                currentQuestionIndexToShow = newIndex + 1;
                CurrentQuestion = Questions[currentQuestionIndex];
            }
        }

    }
}
