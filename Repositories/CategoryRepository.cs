using AutoMapper;
using Biblioteca_API.DataContext;
using Biblioteca_API.DTOs;
using Microsoft.EntityFrameworkCore;
using Biblioteca_API.DTOs.CreateUpdateObjects;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca_API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BibliotecaDBDataContext _context;
        private readonly IMapper _mapper;
        public CategoryRepository(BibliotecaDBDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Category>> GetCategoryAsync()
        {
            return await _context.Categories.ToListAsync();

        }
        public async Task<Category> GetCategoryByIdAsync(Guid id)
        {
            return await _context.Categories.SingleOrDefaultAsync(a => a.IDCategorie == id);
        }
        public async Task CreateCategoryAsync(Category category)
        {
            category.IDCategorie = Guid.NewGuid();
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            Category category = await GetCategoryByIdAsync(id);
            if (category == null)
            {
                return false;
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;


        }
        public async Task<CreateUpdateCategory> UpdateCategoryAsync(Guid id, CreateUpdateCategory category)
        {
            if (!await ExistCategoryAsync(id))
            {
                return null;
            }
            var categoryUpdated = _mapper.Map<Category>(category);
            categoryUpdated.IDCategorie = id;
            _context.Update(categoryUpdated);
            await _context.SaveChangesAsync();
            return category;
        }
        private async Task<bool> ExistCategoryAsync(Guid id)
        {
            return await _context.Categories.CountAsync(a => a.IDCategorie == id) > 0;
        }
        public async Task<CreateUpdateCategory> UpdatePartiallyCategoryAsync(Guid id, CreateUpdateCategory category)
        {
            var categoryFromDB = await GetCategoryByIdAsync(id);
            if (categoryFromDB == null) { return null; }
            if (categoryFromDB.IDCategorie != null && category.IDCategorie != categoryFromDB.IDCategorie)
            {
                categoryFromDB.IDCategorie = categoryFromDB.IDCategorie;
            }
            if (category.NumeCategorie != null && category.NumeCategorie != categoryFromDB.NumeCategorie)
            {
                categoryFromDB.NumeCategorie = categoryFromDB.NumeCategorie;
            }
            if (category.Descriere != null && category.Descriere != categoryFromDB.Descriere)
            {
                categoryFromDB.Descriere = categoryFromDB.Descriere;
            }
            _context.Categories.Update(categoryFromDB);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
