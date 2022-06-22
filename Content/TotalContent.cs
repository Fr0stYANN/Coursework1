﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.INPC;

namespace WpfApp1.Content
{
    public class TotalContent : BaseContent
    {
        private int countRight;
        private int countTotal;
        /// <summary>Количество правильных ответов</summary>
        public int CountRight { get => countRight; set { countRight = value; OnPropertyChanged(); } }

        /// <summary>Количество вопросов в тесте</summary>
        public int CountTotal { get => countTotal; set { countTotal = value; OnPropertyChanged(); } }
        public TotalContent(ExecuteHandler execute, CanExecuteHandler canExecute = null) : base(execute, canExecute) {
            UserRepository userRepository = new UserRepository();
            userRepository.SetPoints(CountRight, DataBank.Login);
        }
    }
}
        