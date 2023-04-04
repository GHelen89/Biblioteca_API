using Biblioteca_API.DTOs.CreateUpdateObjects;
using Biblioteca_API.DTOs;
using Biblioteca_API.Helpers;
using Biblioteca_API.Repositories;

namespace Biblioteca_API.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _repository;
        public BooksService(IBooksRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _repository.GetBooksAsync();
        }
        public async Task<Book> GetBooksByIdAsync(Guid id)
        {
            return await _repository.GetBooksByIdAsync(id);
        }
        public async Task CreateBooksAsync(Book newbooks)
        {
            //ValidationFunctions.ExceptionsWhenDateIsNotValid(newbooks.IDCarte, newbooks.Imprumutata);
            await _repository.CreateBooksAsync(newbooks);
        }
        public async Task<bool> DeleteBooksAsync(Guid id)
        {
            return await _repository.DeleteBooksAsync(id);
        }
        public async Task<CreateUpdateBooks> UpdateBooksAsync(Guid id, CreateUpdateBooks books)
        {
            //ValidationFunctions.ExceptionsWhenDateIsNotValid(books.IDCarte, books.Imprumutata);
            return await _repository.UpdateBooksAsync(id, books);
        }
        public async Task<CreateUpdateBooks> UpdatePartiallyBooksAsync(Guid id, CreateUpdateBooks books)
        {
            //ValidationFunctions.ExceptionsWhenDateIsNotValid(books.IDCarte, books.Imprumutata);
            return await (_repository.UpdatePartiallyBooksAsync(id, books));
        }
    }
}
