using Shared;
using MongoDB.Driver;

namespace ServerAPI.Repositories;

public class ToDoRepositoryMongoDB : IToDoRepository
{
    private IMongoClient client;
        
    private IMongoCollection<BETodoItem> ToDoCollection;

    public ToDoRepositoryMongoDB() {
            // atlas database
            //var password = ""; //add
            //var mongoUri = $"mongodb+srv://olee58:{password}@cluster0.olmnqak.mongodb.net/?retryWrites=true&w=majority";
           
            //local mongodb
            var mongoUri = "mongodb://localhost:27017/";
            
            try
            {
                client = new MongoClient(mongoUri);
            }
            catch (Exception e)
            {
                Console.WriteLine("There was a problem connecting to your " +
                    "Atlas cluster. Check that the URI includes a valid " +
                    "username and password, and that your IP address is " +
                    $"in the Access List. Message: {e.Message}");
            throw; }

            // Provide the name of the database and collection you want to use.
            var dbName = "WebApp";
            var collectionName = "ToDo";

            ToDoCollection = client.GetDatabase(dbName)
               .GetCollection<BETodoItem>(collectionName);
        }

        public void Add(BETodoItem item) {
            var max = 0;
            if (ToDoCollection.Count(Builders<BETodoItem>.Filter.Empty) > 0)
            {
                max = MaxId();
            }
            item.Id = max + 1;
            // alternative:
            //int newid = Guid.NewGuid().GetHashCode();
            //item.Id = newid;
            ToDoCollection.InsertOne(item);
           
        }

        private int MaxId() {
            /*var noFilter = Builders<BETodoItem>.Filter.Empty;
            var elementWithHighestId = collection.Find(noFilter).SortByDescending(r => r.Id).Limit(1).ToList()[0];
            return elementWithHighestId.Id;*/
            return GetAll().Select(t => t.Id).Max();

        }
        
        public void Delete(string title){
            ToDoCollection.DeleteOne(Builders<BETodoItem>.Filter.Eq(t => t.Title, title));
        }

        public List<BETodoItem> GetAll() {
            var noFilter = Builders<BETodoItem>.Filter.Empty;
            return ToDoCollection.Find(noFilter).ToList();
        }

        public void Update(BETodoItem todoItem)
        {
            var updateDef = Builders<BETodoItem>.Update
                .Set(x => x.Title, todoItem.Title)
                .Set(x => x.IsDone, todoItem.IsDone);
                
            ToDoCollection.UpdateOne(x => x.Id == todoItem.Id, updateDef);
        }

        
        /*
             public string Title { get; set; } = string.Empty;
    public bool IsDone { get; set; }
         */
 
}