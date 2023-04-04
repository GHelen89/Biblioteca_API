using System.ComponentModel.DataAnnotations;

namespace Biblioteca_API.DTOs
{
    public class BookLoan
    {
        public DateTime? DataImprumut { get; set; }
        public DateTime? DataRetur { get; set; }
        public Guid IDMembru { get; set; }
        [Key]
        public Guid IDImprumut { get; set; }
        public Guid IDCarte { get; set; }

    }
}
