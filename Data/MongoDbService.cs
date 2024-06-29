using MongoDB.Driver;

namespace MongoDB_OData.Data
{
    public class MongoDbService
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoDatabase _database;
        public MongoDbService(IConfiguration configuration) 
        {
            _configuration = configuration;

            var connectionString = _configuration.GetConnectionString("DbConnection");
            var databaseName = _configuration.GetSection("MongoDbSettings:DatabaseName").Value;

            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);

            _database = mongoClient.GetDatabase(databaseName);
        }

        public IMongoDatabase? Database => _database;
    }
}
