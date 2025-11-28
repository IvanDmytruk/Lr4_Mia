using LW4_MIA_2.Models;
using MongoDB.Driver;

namespace LW4_MIA_2.Repositories
{
    public class ClubRepository: IRepositoriesClub
    {
        private readonly IMongoCollection<Club> _collection;

        public ClubRepository(IConfiguration config)
        {
            var client = new MongoClient("mongodb+srv://ivandmytruk42_db_user:lwokr123@db.rdcvntl.mongodb.net/?appName=DB");
            var database = client.GetDatabase("LW4_MIA_2");
            _collection = database.GetCollection<Club>("Clubs");
        }

        public async Task<List<Club>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<Club?> GetByIdAsync(string id) =>
            await _collection.Find(c => c.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Club entity) =>
            await _collection.InsertOneAsync(entity);

        public async Task UpdateAsync(string id, Club entity) =>
            await _collection.ReplaceOneAsync(c => c.Id == id, entity);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(c => c.Id == id);
    }
}
