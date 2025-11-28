using LW4_MIA_2.Models;
using MongoDB.Driver;

namespace LW4_MIA_2.Repositories
{
    public class UserRepository : IRepositoriesUser
    {
        private readonly IMongoCollection<User> _collection;

        public UserRepository(IConfiguration config)
        {
            var client = new MongoClient("mongodb+srv://ivandmytruk42_db_user:lwokr123@db.rdcvntl.mongodb.net/?appName=DB");
            var database = client.GetDatabase("LW4_MIA_2");
            _collection = database.GetCollection<User>("Users");
        }

        public async Task<List<User>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<User?> GetByIdAsync(string id) =>
            await _collection.Find(u => u.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(User entity) =>
            await _collection.InsertOneAsync(entity);

        public async Task UpdateAsync(string id, User entity) =>
            await _collection.ReplaceOneAsync(u => u.Id == id, entity);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(u => u.Id == id);

        public Task<List<User>> GetUsersAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
