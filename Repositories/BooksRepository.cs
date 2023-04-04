using AutoMapper;
using Biblioteca_API.DataContext;
using Biblioteca_API.DTOs;
using Microsoft.EntityFrameworkCore;
using Biblioteca_API.DTOs.CreateUpdateObjects;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca_API.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BibliotecaDBDataContext _context;
        private readonly IMapper _mapper;
        public BooksRepository(BibliotecaDBDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();

        }
        public async Task<Book> GetBooksByIdAsync(Guid id)
        {
            return await _context.Books.SingleOrDefaultAsync(a => a.IDCarte == id);
        }
        public async Task CreateBooksAsync(Book books)
        {
            books.IDCarte = Guid.NewGuid();
            _context.Books.Add(books);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteBooksAsync(Guid id)
        {
            Book books = await GetBooksByIdAsync(id);
            if (books == null)
            {
                return false;
            }
            _context.Books.Remove(books);
            await _context.SaveChangesAsync();
            return true;


        }
        public async Task<CreateUpdateBooks> UpdateBooksAsync(Guid id, CreateUpdateBooks books)
        {
            if (!await ExistBooksAsync(id))
            {
                return null;
            }
            var booksUpdated = _mapper.Map<Book>(books);
            booksUpdated.IDCarte = id;
            _context.Update(booksUpdated);
            await _context.SaveChangesAsync();
            return books;
        }
        private async Task<bool> ExistBooksAsync(Guid id)
        {
            return await _context.Books.CountAsync(a => a.IDCarte == id) > 0;
        }
        public async Task<CreateUpdateBooks> UpdatePartiallyBooksAsync(Guid id, CreateUpdateBooks books)
        {
            var bookFromDB = await GetBooksByIdAsync(id);
            if (bookFromDB == null) { return null; }
            if (books.IDCarte!= null && books.IDCarte != bookFromDB.IDCarte)
            {
                bookFromDB.IDCarte = books.IDCarte;
            }
            if (books.NumeCarte != null && books.NumeCarte != bookFromDB.NumeCarte)
            {
                bookFromDB.NumeCarte = books.NumeCarte;
            }
            if (books.Editura != null && books.Editura != bookFromDB.Editura)
            {
                bookFromDB.Editura = books.Editura;
            }
            if (books.Autor != null && books.Autor != bookFromDB.Autor)
            {
                bookFromDB.Autor = books.Autor;
            }
            if (books.AnAparitie != null && books.AnAparitie != bookFromDB.AnAparitie)
            {
                bookFromDB.AnAparitie = books.AnAparitie;
            }
            //if (books.Imprumutata != null && books.Imprumutata != bookFromDB.Imprumutata)
            //{
            //    bookFromDB.Imprumutata = books.Imprumutata;
            //}
            _context.Books.Update(bookFromDB);
            await _context.SaveChangesAsync();
            return books;
        }

    }
}
