using EventosVista.MVVM.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosVista.MVVM.ICommand
{
    internal class FindAllCommand : ICommand
    {
        private List<Event> events;

        private IEventRepository eventRepository;

        public FindAllCommand()
        {
            events = new List<Event>();
            eventRepository = RepositoryFactory.getInstance().GetEventRepository();
        }

        public void Execute()
        {
            events = eventRepository.listAllEvents();
        }

        public List<Event> getEvents()
        {
            return events;
        }
    }
}
