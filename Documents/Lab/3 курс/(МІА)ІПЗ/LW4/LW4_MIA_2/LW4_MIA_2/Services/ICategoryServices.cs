using LW4_MIA_2.Models;

namespace LW4_MIA_2.Services
{
    public interface ICategoryServices
    {
        Task CreateCategoryAsync(Category category);
        Task<List<Category>> GetCategoryAsync();
        Task<Category?> GetCategoryByIdAsync(string id);
        Task UpdateCategoryAsync(string id, Category category);
        Task DeleteCategoryAsync(string id);
    }
}