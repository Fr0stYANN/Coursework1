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
        private bool isVisible = true;
        public bool IsVisible { get => isVisible; set { isVisible = value; OnPropertyChanged(); } }
        public int CountRight { get => countRight; set { countRight = value; OnPropertyChanged(); } }
        public int CountTotal { get => countTotal; set { countTotal = value; OnPropertyChanged(); } }
        public TotalContent(ExecuteHandler execute, CanExecuteHandler canExecute = null) : base(execute, canExecute) {
        }
    }
}
        
