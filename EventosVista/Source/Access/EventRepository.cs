using EventosVista.Source.Model;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventosVista.Source.Access
{
    public class EventRepository : IEventRepository
    {

        readonly MongoClientSettings settings = MongoClientSettings.FromConnectionString("mongodb+srv://unicauca:conectada@unicaucaconectada.avvq7.mongodb.net/UnicaucaConectada?retryWrites=true&w=majority");
        MongoClient client;
        IMongoDatabase database;
        IMongoCollection<Event> collection;

        public EventRepository()
        {
            _ = InitDB();
        }
        public bool saveEvent(Event newEvent)
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
        public bool deleteEvent(Event eventDeleted)
        {
            if (eventDeleted == null)
            {
                return false;
            }
            var ret = collection.DeleteOne(c => c.Id == eventDeleted.Id);

            return ret.DeletedCount == 1;
        }
        public bool updateEvent(Event newEvent)
        {
            if (newEvent == null)
            {
                return false;
            }
            var filter = Builders<Event>.Filter.Eq("id", newEvent.Id);
            var ret = collection.ReplaceOne(filter, newEvent);

            return ret.ModifiedCount == 1;
        }

        public Event? findEvent(string event_id)
        {
            var ret = collection.Find(d => d.Id == event_id);


            return ret.FirstOrDefault() == null ? null : ret.First();

        }

        public List<Event> listAllEvents()
        {
            List<Event> list = collection.Find(d => true).ToList();

            return list;
        }



        private async Task InitDB()
        {

            var mongoClient = new MongoClient(settings);

            var mongoDatabase = mongoClient.GetDatabase("unicauca_conectada");

            var eventsDB = mongoDatabase.GetCollection<Event>("events");

            this.client = mongoClient;
            this.database = mongoDatabase;
            this.collection = eventsDB;

            var options = new CreateIndexOptions { Unique = true };
            collection.Indexes.CreateOne("{ title : 1 }", options);
        }
    }

}
