using EventosVista.Source.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosVista.Source.Core.Command
{
    internal class FindAllEventsCommand : ICommand
    {
        private List<Event> events;

        private IEventRepository _eventRepository;

        public FindAllEventsCommand()
        {
            events = new List<Event>();
            _eventRepository = RepositoryFactory.getInstance().GetEventRepository();
        }

        public void Execute()
        {
            events = _eventRepository.listAllEvents();
        }

        public List<Event> getEvents()
        {
            return events;
        }
    }
}
