﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CustomerList.WPF.ViewModels
{
    public abstract class BindableBase : INotifyPropertyChanged
    {

        // Occurs when a property value changes.
        public event PropertyChangedEventHandler PropertyChanged;


        // Notifies listeners that a property value has changed.
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        // Checks if a property already matches a desired value. Sets the property and
        // notifies listeners only when necessary.
        protected bool Set<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
