using Biblioteca_API.DTOs;
using Microsoft.EntityFrameworkCore;
namespace Biblioteca_API.DataContext
{
    public class BibliotecaDBDataContext:DbContext
    {
        public BibliotecaDBDataContext(DbContextOptions<BibliotecaDBDataContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<BookLoan> BookLoans { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
