interface IEventRepository
{
    bool saveEvent(Event newEvent);

    bool updateEvent(Event newEvent);

    Event? findEvent(string event_id);

    bool deleteEvent(Event newEvent);

    List<Event> listAllEvents();

}