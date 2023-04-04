using System.ComponentModel.DataAnnotations;
using Biblioteca_API.DTOs;
using Biblioteca_API.DataContext;
using Biblioteca_API.DTOs.CreateUpdateObjects;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


namespace Biblioteca_API.Repositories
{
    public class BookLoansRepository : IBookLoansRepository
    {
        private readonly BibliotecaDBDataContext _context;
        private readonly IMapper _mapper;
        public BookLoansRepository(BibliotecaDBDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BookLoan>> GetBookLoanAsync()
        {
            return await _context.BookLoans.ToListAsync();

        }
        public async Task<BookLoan>GetBookLoanByIdAsync(Guid id)
        {
            return await _context.BookLoans.SingleOrDefaultAsync(a => a.IDImprumut == id);
        }
        public async Task CreateBookLoanAsync(BookLoan bookLoan)
        {
            bookLoan.IDImprumut = Guid.NewGuid();
            _context.BookLoans.Add(bookLoan);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteBookLoanAsync(Guid id)
        {
            BookLoan bookLoan = await GetBookLoanByIdAsync(id);
            if (bookLoan == null)
            {
                return false;
            }
            _context.BookLoans.Remove(bookLoan);
            await _context.SaveChangesAsync();
            return true;


        }
        public async Task<CreateUpdateBookLoans> UpdateBookLoanAsync(Guid id, CreateUpdateBookLoans bookLoans)
        {
            if (!await ExistBookLoanAsync(id))
            {
                return null;
            }
            var bookLoanUpdated = _mapper.Map<BookLoan>(bookLoans);
            bookLoanUpdated.IDImprumut = id;
            _context.Update(bookLoanUpdated);
            await _context.SaveChangesAsync();
            return bookLoans;
        }
        private async Task<bool> ExistBookLoanAsync(Guid id)
        {
            return await _context.BookLoans.CountAsync(a => a.IDImprumut == id) > 0;
        }
        public async Task<CreateUpdateBookLoans> UpdatePartiallyBookLoanAsync(Guid id ,CreateUpdateBookLoans bookLoans)
        {
            var bookLoanFromDB = await GetBookLoanByIdAsync(id);
            if(bookLoanFromDB == null) { return null; }
            if (bookLoans.DataImprumut != null && bookLoans.DataImprumut != bookLoanFromDB.DataImprumut)
            {
                bookLoanFromDB.DataImprumut = bookLoanFromDB.DataImprumut;
            }
            if (bookLoans.DataRetur != null && bookLoans.DataRetur != bookLoanFromDB.DataRetur)
            {
                bookLoanFromDB.DataRetur = bookLoanFromDB.DataRetur;
            }
            _context.BookLoans.Update(bookLoanFromDB);
            await _context.SaveChangesAsync();
            return bookLoans;
        }
    }
    
}
