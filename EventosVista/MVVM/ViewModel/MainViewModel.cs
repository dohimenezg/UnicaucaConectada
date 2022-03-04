﻿using EventosVista.MVVM.Core;
using EventosVista.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosVista.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand EventViewComand { get; set; }
        public RelayCommand PostEventViewComand { get; set; }
        public RelayCommand LogInViewComand { get; set; }
        public RelayCommand RegisterViewComand { get; set; }
        public EventViewModel EventVM { get; set; }
        public PostEventViewModel PostEventVM { get; set; }
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
            PostEventVM = new PostEventViewModel();
            LogInVM = new LogInViewModel();
            RegisterVM = new RegisterViewModel();
            PostEventVM = new PostEventViewModel();

            CurrentView = EventVM;

            EventViewComand = new RelayCommand(o =>{
                CurrentView = EventVM;
            });

            PostEventViewComand = new RelayCommand(o => {
                CurrentView = PostEventVM;
            });

            LogInViewComand = new RelayCommand(o => {
                CurrentView = LogInVM;
            });

            RegisterViewComand = new RelayCommand(o =>
            {
                CurrentView = RegisterVM;
            });

            PostEventViewComand = new RelayCommand(o =>
            {
                CurrentView = PostEventVM;
            });

            

        }
    }
}
