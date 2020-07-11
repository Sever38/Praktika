﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1.ViewModel
{
    class BaseHelper : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}