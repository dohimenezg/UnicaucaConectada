using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

public class EventRepository : IEventRepository
{

    MongoClientSettings settings = MongoClientSettings.FromConnectionString("mongodb+srv://unicauca:conectada@unicaucaconectada.avvq7.mongodb.net/UnicaucaConectada?retryWrites=true&w=majority");
    MongoClient client;
    IMongoDatabase database;
    IMongoCollection<Event> collection;

    public EventRepository()
    {
        initDB(); 
    }
    public Boolean saveEvent(Event newEvent)
    {
        try
        {
            collection.InsertOne(newEvent);
            return true;
        }
        catch (MongoWriteException e)
        {
           return false;
        }
        
    }
    public Boolean deleteEvent(Event deletedEvent)
    {
        if(deletedEvent == null)
        {
            return false;
        }
        var ret = collection.DeleteOne(c => c.id == deletedEvent.id);

        return ret.DeletedCount == 1? true: false;
    }
    public Boolean updateEvent(Event updatedEvent)
    {
        if (updatedEvent == null)
        {
            return false;
        }
        var filter = Builders<Event>.Filter.Eq("id", updatedEvent.id);
        var ret = collection.ReplaceOne(filter, updatedEvent);

        return ret.ModifiedCount == 1 ? true : false;
    }

    public Event? findEvent(string event_id)
    {
        var ret = collection.Find(d => d.id == event_id);

        
        return ret.FirstOrDefault() == null ? null : ret.First();

    }

    public List<Event> listAllEvents()
    {
        List<Event> list = collection.Find(d => true).ToList();

        return list;
    }



    private async void initDB()
    {
        
        var client = new MongoClient(settings);
        
        var database = client.GetDatabase("unicauca_conectada");

        var eventsDB = database.GetCollection<Event>("events");

        this.client = client;
        this.database = database;
        this.collection = (IMongoCollection<Event>)eventsDB;

        var options = new CreateIndexOptions { Unique = true };
        collection.Indexes.CreateOne("{ title : 1 }", options);
    }
}
