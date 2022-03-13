using EventosVista.MVVM.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EventosVista.MVVM.ViewModel
{
    public class EventViewModel
    {
        private EventRepository EventRepository;
        public ObservableCollection<Event> Events { get; set; }
        public EventViewModel()
        {
            EventRepository = new EventRepository();
            Events = new ObservableCollection<Event>();
            PopulateCollection();
        }

        void PopulateCollection()
        {
            List<Event> list = EventRepository.listAllEvents();

            foreach (Event e in list)
            {
                Events.Add(e);
            }
        }
    }
}
