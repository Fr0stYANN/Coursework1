using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.INPC;
using WpfApp1.TestClasses;

namespace WpfApp1.ViewModels
{
    public class AnswerViewModel : OnPropertyChangedBaseImplementation
    {
        private readonly TestAnswer testAnswer;
        private bool isRightView;
        public AnswerViewModel(TestAnswer _testAnswer)
        {
            testAnswer = _testAnswer;
        }
        public string Text => testAnswer.AnswerText;
        public bool IsRightView { get => isRightView; set { isRightView = value; OnPropertyChanged();} }
        public bool Value => IsRightView == testAnswer.IsRight;
    }
}
