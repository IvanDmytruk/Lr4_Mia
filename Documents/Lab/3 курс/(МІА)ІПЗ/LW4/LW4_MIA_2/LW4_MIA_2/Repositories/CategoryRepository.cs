using LW4_MIA_2.Models;
using MongoDB.Driver;

namespace LW4_MIA_2.Repositories
{
    public class CategoryRepository:IRepositoriesCategory
    {
        private readonly IMongoCollection<Category> _collection;

        public CategoryRepository(IConfiguration config)
        {
            var client = new MongoClient("mongodb+srv://ivandmytruk42_db_user:lwokr123@db.rdcvntl.mongodb.net/?appName=DB");
            var database = client.GetDatabase("LW4_MIA_2");
            _collection = database.GetCollection<Category>("Categories");
        }

        public async Task<List<Category>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<Category?> GetByIdAsync(string id) =>
            await _collection.Find(c => c.Id.ToString() == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Category entity) =>
            await _collection.InsertOneAsync(entity);

        public async Task UpdateAsync(string id, Category entity) =>
            await _collection.ReplaceOneAsync(c => c.Id.ToString() == id, entity);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(c => c.Id.ToString() == id);
    }
}
