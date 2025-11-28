using LW4_MIA_2.Models;

namespace LW4_MIA_2.Services
{
    public interface IClubServices
    {
        Task<List<Club>> GetClubsAsync();
        Task<Club?> GetClubByIdAsync(string id);
        Task CreateClubAsync(Club club);
        Task UpdateClubAsync(string id, Club club);
        Task DeleteClubAsync(string id);
    }
}
