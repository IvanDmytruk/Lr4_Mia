using LW4_MIA_2.Models;
using MongoDB.Driver;

namespace LW4_MIA_2.Repositories
{
    public class TodoRepository : IRepositoriesTodo
    {
        private readonly IMongoCollection<Todo> _collection;

        public TodoRepository(IConfiguration config)
        {
            var client = new MongoClient("mongodb+srv://ivandmytruk42_db_user:lwokr123@db.rdcvntl.mongodb.net/?appName=DB");
            var database = client.GetDatabase("LW4_MIA_2");
            _collection = database.GetCollection<Todo>("Todos");
        }

        public async Task<List<Todo>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<Todo?> GetByIdAsync(string id) =>
            await _collection.Find(t => t.Id.ToString() == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Todo entity) =>
            await _collection.InsertOneAsync(entity);

        public async Task UpdateAsync(string id, Todo entity) =>
            await _collection.ReplaceOneAsync(t => t.Id.ToString() == id, entity);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(t => t.Id.ToString() == id);

        public Task<List<Todo>> GetTodosAsync(Todo todo)
        {
            throw new NotImplementedException();
        }
    }
}
