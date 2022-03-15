using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

public class UserRepository : IUserRepository
{

    MongoClientSettings settings = MongoClientSettings.FromConnectionString("mongodb+srv://unicauca:conectada@unicaucaconectada.avvq7.mongodb.net/UnicaucaConectada?retryWrites=true&w=majority");
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
        var ret = collection.DeleteOne(c => c.id == deletedUser.id);

        return ret.DeletedCount == 1 ? true : false;
    }
    public Boolean updateUser(User updatedUser)
    {
        var filter = Builders<User>.Filter.Eq("id", updatedUser.id);
        var ret = collection.ReplaceOne(filter, updatedUser);

        return ret.ModifiedCount == 1 ? true : false;
    }

    public User? findUser(string User_id)
    {
        var ret = collection.Find(d => d.nombre_usuario == User_id);
        return ret.FirstOrDefault() == null ? null : ret.First();

    }

    public List<User> listAllUsers()
    {
        List<User> list = collection.Find(d => true).ToList();

        return list;
    }



    private void initDB()
    {

        var client = new MongoClient(settings);

        var database = client.GetDatabase("unicauca_conectada");

        var UsersDB = database.GetCollection<User>("users");

        this.client = client;
        this.database = database;
        this.collection = (IMongoCollection<User>)UsersDB;

        var options = new CreateIndexOptions { Unique = true };
        collection.Indexes.CreateOne("{ username : 1 }", options);
    }
}
