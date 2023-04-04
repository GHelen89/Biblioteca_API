using Biblioteca_API.DTOs;
using Biblioteca_API.DTOs.CreateUpdateObjects;

namespace Biblioteca_API.Repositories
{
    public interface IBooksRepository
    {
        public Task<IEnumerable<Book>> GetBooksAsync();
        public Task<Book> GetBooksByIdAsync(Guid id);
        public Task CreateBooksAsync(Book books);
        public Task<bool> DeleteBooksAsync(Guid id);
        public Task<CreateUpdateBooks> UpdateBooksAsync(Guid id, CreateUpdateBooks books);
        public Task<CreateUpdateBooks> UpdatePartiallyBooksAsync(Guid id, CreateUpdateBooks books);

    }
}
