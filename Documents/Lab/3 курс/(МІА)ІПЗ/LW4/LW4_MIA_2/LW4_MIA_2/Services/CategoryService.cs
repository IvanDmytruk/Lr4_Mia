using LW4_MIA_2.Models;
using LW4_MIA_2.Models;
using LW4_MIA_2.Repositories;

namespace LW4_MIA_2.Services
{
    public class CategoryService : ICategoryServices
    {
        private readonly IRepositoriesCategory _repository;
        public CategoryService(IRepositoriesCategory repository)
        {
            _repository = repository;
        }

        public async Task CreateCategoryAsync(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            await _repository.CreateAsync(category);
        }

        public async Task<Category?> GetCategoryByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Невірний ідентифікатор категорії", nameof(id));

            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<Category>> GetCategoryAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task UpdateCategoryAsync(string id, Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            await _repository.UpdateAsync(id, category);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
