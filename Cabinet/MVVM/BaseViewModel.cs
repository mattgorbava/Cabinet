﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet.MVVM
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool TextBoxFieldsNotNull()
        {
            return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(CNP) &&
                !string.IsNullOrEmpty(Address) && !string.IsNullOrEmpty(PhoneNumber);
        }
    }
}
