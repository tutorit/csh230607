using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Calculation : INotifyPropertyChanged
    {
        private int _fig1=4;
        private int _fig2=6;

        public int Result => Figure1 + Figure2;

        public int Figure1
        {
            get
            {
                return _fig1;
            }
            set
            {
                _fig1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Figure1"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Result"));
            }
        }

        public int Figure2
        {
            get
            {
                return _fig2;
            }
            set
            {
                _fig2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Figure1"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Result"));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
