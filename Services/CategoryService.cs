using Biblioteca_API.DTOs.CreateUpdateObjects;
using Biblioteca_API.DTOs;
using Biblioteca_API.Repositories;

namespace Biblioteca_API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Category>> GetCategoryAsync()
        {
            return await _repository.GetCategoryAsync();
        }
        public async Task<Category> GetCategoryByIdAsync(Guid id)
        {
            return await _repository.GetCategoryByIdAsync(id);
        }
        public async Task CreateCategoryAsync(Category newcategory)
        {
            //ValidationFunctions.ExceptionsWhenDateIsNotValid(newcategory.IDCarte, newcategory.Imprumutata);
            await _repository.CreateCategoryAsync(newcategory);
        }
        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            return await _repository.DeleteCategoryAsync(id);
        }
        public async Task<CreateUpdateCategory> UpdateCategoryAsync(Guid id, CreateUpdateCategory category)
        {
            //ValidationFunctions.ExceptionsWhenDateIsNotValid(category.IDCarte, category.Imprumutata);
            return await _repository.UpdateCategoryAsync(id, category);
        }
        public async Task<CreateUpdateCategory> UpdatePartiallyCategoryAsync(Guid id, CreateUpdateCategory category)
        {
            //ValidationFunctions.ExceptionsWhenDateIsNotValid(category.IDCarte, category.Imprumutata);
            return await (_repository.UpdatePartiallyCategoryAsync(id, category));
        }
    }
}
