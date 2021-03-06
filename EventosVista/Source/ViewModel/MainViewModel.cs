using EventosVista.Source.Core;
using EventosVista.Source.Core.Command;

namespace EventosVista.Source.ViewModel
{
    internal class MainViewModel : ObservableObject
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
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {

            EventVM = new EventViewModel();
            PostEventVM = new PostEventViewModel();
            LogInVM = new LogInViewModel();
            RegisterVM = new RegisterViewModel();

            CurrentView = EventVM;

            EventViewComand = new RelayCommand(o =>
            {
                CurrentView = EventVM;
            });

            PostEventViewComand = new RelayCommand(o =>
            {
                CurrentView = PostEventVM;
            });

            LogInViewComand = new RelayCommand(o =>
            {
                CurrentView = LogInVM;
            });

            RegisterViewComand = new RelayCommand(o =>
            {
                CurrentView = RegisterVM;
            });
        }
        public void HomeRouter()
        {
            CurrentView = EventVM;
        }
        public void RegisterRouter()
        {
            CurrentView = RegisterVM;
        }
    }
}
