using Biblioteca_API.DTOs;
using Biblioteca_API.DTOs.CreateUpdateObjects;

namespace Biblioteca_API.Repositories
{
    public interface IBookLoansRepository
    {
        public Task<IEnumerable<BookLoan>> GetBookLoanAsync();
        public Task<BookLoan>GetBookLoanByIdAsync(Guid id);
        public Task CreateBookLoanAsync(BookLoan bookLoan);
        public Task <bool>DeleteBookLoanAsync(Guid id);
        public Task <CreateUpdateBookLoans> UpdateBookLoanAsync(Guid id, CreateUpdateBookLoans bookLoan);
        public Task<CreateUpdateBookLoans>UpdatePartiallyBookLoanAsync(Guid id, CreateUpdateBookLoans bookLoan);
    }
}
