﻿using EventosVista.MVVM.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosVista.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public RelayCommand EventViewComand { get; set; }
        public RelayCommand LogInViewComand { get; set; }
        public RelayCommand RegisterViewComand { get; set; }
        public EventViewModel EventVM { get; set; }
        public LogInViewModel LogInVM { get; set; }
        public RegisterViewModel RegisterVM { get; set; }
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value;
                onPropertyChanged();
            }
        }

        public MainViewModel()
        {
            EventVM = new EventViewModel();
            LogInVM = new LogInViewModel();
            RegisterVM = new RegisterViewModel();

            CurrentView = EventVM;

            EventViewComand = new RelayCommand(o =>{
                CurrentView = EventVM;
            });

            LogInViewComand = new RelayCommand(o => {
                CurrentView = LogInVM;
            });

            RegisterViewComand = new RelayCommand(o =>
            {
                CurrentView = RegisterVM;
            });
        }
    }
}
