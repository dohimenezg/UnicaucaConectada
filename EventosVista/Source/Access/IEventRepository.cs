using EventosVista.Source.Model;
using System.Collections.Generic;

namespace EventosVista.Source.Access
{
    interface IEventRepository
    {
        bool saveEvent(Event newEvent);

        bool updateEvent(Event newEvent);

        Event? findEvent(string event_id);

        bool deleteEvent(Event eventDeleted);

        List<Event> listAllEvents();

    }
}
