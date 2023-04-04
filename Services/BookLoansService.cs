using Biblioteca_API.DTOs;
using Biblioteca_API.Repositories;
using Biblioteca_API.DTOs.CreateUpdateObjects;
using Biblioteca_API.Helpers;

namespace Biblioteca_API.Services
{
    public class BookLoansService:IBookLoansService
    {

        private readonly IBookLoansRepository _repository;
        public BookLoansService(IBookLoansRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<BookLoan>> GetBookLoanAsync()
        {
            return await _repository.GetBookLoanAsync();
        }
        public async Task<BookLoan>GetBookLoanByIdAsync(Guid id)
        {
            return await _repository.GetBookLoanByIdAsync(id);
        }
        public async Task CreateBookLoanAsync(BookLoan newbookLoan)
        {
            ValidationFunctions.ExceptionsWhenDateIsNotValid(newbookLoan.DataImprumut, newbookLoan.DataRetur);
            await _repository.CreateBookLoanAsync(newbookLoan);
        }
        public async Task <bool>DeleteBookLoanAsync(Guid id)
        {
            return await _repository.DeleteBookLoanAsync(id);
        }
        public async Task<CreateUpdateBookLoans> UpdateBookLoanAsync(Guid id, CreateUpdateBookLoans bookLoans)
        {
            ValidationFunctions.ExceptionsWhenDateIsNotValid(bookLoans.DataImprumut, bookLoans.DataRetur);
            return await _repository.UpdateBookLoanAsync(id, bookLoans);
        }
        public  async Task<CreateUpdateBookLoans> UpdatePartiallyBookLoanAsync(Guid id, CreateUpdateBookLoans bookLoan)
        {
            ValidationFunctions.ExceptionsWhenDateIsNotValid(bookLoan.DataImprumut, bookLoan.DataRetur);
            return await (_repository.UpdatePartiallyBookLoanAsync(id, bookLoan));
        }
    }
}
