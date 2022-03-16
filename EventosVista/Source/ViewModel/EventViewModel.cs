using EventosVista.Source.Core.Command;
using EventosVista.Source.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EventosVista.Source.ViewModel
{
    public class EventViewModel
    {
        public ObservableCollection<Event> Events { get; set; }
        public EventViewModel()
        {
            Events = new ObservableCollection<Event>();
            PopulateCollection();
        }

        public void PopulateCollection()
        {
            FindAllEventsCommand findAllCommand = new FindAllEventsCommand();
            Invoker.getInstance().setCommand(findAllCommand);
            Invoker.getInstance().execute();
            List<Event> list = findAllCommand.getEvents();

            foreach (Event e in list)
            {
                Events.Add(e);
            }
        }
    }
}
