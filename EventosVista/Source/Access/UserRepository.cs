using EventosVista.Source.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace EventosVista.Source.Access
{
    public class UserRepository : IUserRepository
    {

        readonly MongoClientSettings settings = MongoClientSettings.FromConnectionString("mongodb+srv://unicauca:conectada@unicaucaconectada.avvq7.mongodb.net/UnicaucaConectada?retryWrites=true&w=majority");
        MongoClient client;
        IMongoDatabase database;
        IMongoCollection<User> collection;

        public UserRepository()
        {
            initDB();
        }
        public Boolean saveUser(User newUser)
        {
            try
            {
                collection.InsertOne(newUser);
                return true;
            }
            catch (MongoWriteException e)
            {
                return false;
            }

        }
        public Boolean deleteUser(User deletedUser)
        {
            if (deletedUser == null)
            {
                return false;
            }
            var ret = collection.DeleteOne(c => c.Id == deletedUser.Id);

            return ret.DeletedCount == 1;
        }
        public Boolean updateUser(User updatedUser)
        {
            var filter = Builders<User>.Filter.Eq("id", updatedUser.Id);
            var ret = collection.ReplaceOne(filter, updatedUser);

            return ret.ModifiedCount == 1;
        }

        public User? findUser(string user_id)
        {
            var ret = collection.Find(d => d.Nombre_Usuario == user_id);
            return ret.FirstOrDefault() == null ? null : ret.First();

        }

        public List<User> listAllUsers()
        {
            List<User> list = collection.Find(d => true).ToList();

            return list;
        }



        private void initDB()
        {

            var mongoClient = new MongoClient(settings);

            var mongoDatabase = mongoClient.GetDatabase("unicauca_conectada");

            var UsersDB = mongoDatabase.GetCollection<User>("users");

            this.client = mongoClient;
            this.database = mongoDatabase;
            this.collection = UsersDB;

            var options = new CreateIndexOptions { Unique = true };
            collection.Indexes.CreateOne("{ username : 1 }", options);
        }
    }
}

