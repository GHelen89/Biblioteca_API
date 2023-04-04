using Biblioteca_API.DTOs.CreateUpdateObjects;
using Biblioteca_API.DTOs;

namespace Biblioteca_API.Services
{
    public interface IBooksService
    {
        public Task<IEnumerable<Book>> GetBooksAsync();
        public Task<Book> GetBooksByIdAsync(Guid id);
        public Task CreateBooksAsync(Book newbook);
        public Task<bool> DeleteBooksAsync(Guid id);
        public Task<CreateUpdateBooks> UpdateBooksAsync(Guid id, CreateUpdateBooks books);
        public Task<CreateUpdateBooks> UpdatePartiallyBooksAsync(Guid id, CreateUpdateBooks books);
    }
}
