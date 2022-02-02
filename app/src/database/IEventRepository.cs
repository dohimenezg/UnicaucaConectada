interface IEventRepository
{
    Boolean saveEvent(Event newEvent);

    Boolean updateEvent(Event newEvent);

    Event? findEvent(string event_id);

    Boolean deleteEvent(Event newEvent);

    List<Event> listAllEvents();

}