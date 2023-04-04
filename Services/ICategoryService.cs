using Biblioteca_API.DTOs.CreateUpdateObjects;
using Biblioteca_API.DTOs;

namespace Biblioteca_API.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetCategoryAsync();
        public Task<Category> GetCategoryByIdAsync(Guid id);
        public Task CreateCategoryAsync(Category newcategory);
        public Task<bool> DeleteCategoryAsync(Guid id);
        public Task<CreateUpdateCategory> UpdateCategoryAsync(Guid id, CreateUpdateCategory category);
        public Task<CreateUpdateCategory> UpdatePartiallyCategoryAsync(Guid id, CreateUpdateCategory category);
    }
}
