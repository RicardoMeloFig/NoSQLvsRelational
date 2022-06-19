using MongoDB.Driver;
using MongoDB.Bson;


namespace NoSQLvsRelational
{

    public class MongoDB_CRUD
    {

        MongoClient dbClient = new MongoClient("mongodb://localhost:27017/");
        IMongoDatabase database;
        IMongoCollection<BsonDocument> collection;

        public MongoDB_CRUD()
        {
            this.database = dbClient.GetDatabase("SQL_VS_NOSQL");
            this.collection = database.GetCollection<BsonDocument>("MyFirstCollection");

        }

        public Task insertDocument()
        {
            BsonDocument mockedDocument = new BsonDocument
            {
                { "teste", "MockedInser" }
            };
            return collection.InsertOneAsync(mockedDocument);
        }


        public Task updateDocument(ObjectId objectId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", objectId);
            var update = Builders<BsonDocument>.Update.Set("teste", "UpdatedName123");

            return collection.UpdateOneAsync(filter, update);
        }

        public Task deleteDocument(ObjectId objectId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", objectId);
            return collection.DeleteOneAsync(filter);
        }

        public Task getDocumentById(ObjectId objectId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", objectId);
            return collection.Find(filter).FirstAsync();
        }

        public Task getAllDocs()
        {
            return collection.Find(new BsonDocument()).ToListAsync();
        }


    }
}



