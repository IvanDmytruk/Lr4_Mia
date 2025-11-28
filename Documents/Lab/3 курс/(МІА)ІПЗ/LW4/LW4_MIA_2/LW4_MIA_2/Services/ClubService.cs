using LW4_MIA_2.Models;
using LW4_MIA_2.Repositories;

namespace LW4_MIA_2.Services
{
    public class ClubService : IClubServices
    {
        private readonly IRepositoriesClub _clubs;

        public ClubService(IRepositoriesClub clubs)
        {
            _clubs = clubs;
        }

        public async Task<List<Club>> GetClubsAsync()
        {
            return await _clubs.GetAllAsync();
        }

        public async Task<Club?> GetClubByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Некоректний ідентифікатор клубу", nameof(id));

            return await _clubs.GetByIdAsync(id);
        }

        public async Task CreateClubAsync(Club club)
        {
            if (club == null)
                throw new ArgumentNullException(nameof(club));

            await _clubs.CreateAsync(club);
        }

        public async Task UpdateClubAsync(string id, Club club)
        {
            if (club == null)
                throw new ArgumentNullException(nameof(club));

            await _clubs.UpdateAsync(id, club);
        }

        public async Task DeleteClubAsync(string id)
        {
            await _clubs.DeleteAsync(id);
        }
    }
}
