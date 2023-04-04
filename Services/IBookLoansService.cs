using Biblioteca_API.DTOs;
using Biblioteca_API.DTOs.CreateUpdateObjects;


namespace Biblioteca_API.Services
{
    public interface IBookLoansService
    {
        public Task<IEnumerable<BookLoan>> GetBookLoanAsync();
        public Task<BookLoan> GetBookLoanByIdAsync(Guid id);  
        public Task CreateBookLoanAsync(BookLoan newbookLoan); 
        public Task<bool> DeleteBookLoanAsync(Guid id);
        public Task<CreateUpdateBookLoans> UpdateBookLoanAsync(Guid id, CreateUpdateBookLoans bookLoans);
        public Task<CreateUpdateBookLoans> UpdatePartiallyBookLoanAsync(Guid id ,CreateUpdateBookLoans bookLoan);
    }
}
