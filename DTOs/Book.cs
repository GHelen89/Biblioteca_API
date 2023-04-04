using System.ComponentModel.DataAnnotations;

namespace Biblioteca_API.DTOs
{
    public class Book
    {
        [Key]
        public Guid IDCarte { get; set; }
        public string NumeCarte { get; set; }
        public string Autor { get; set; }
        public string Editura { get; set; }
        public DateTime AnAparitie { get; set; }

        public Boolean Imprumutata { get; set; }
    }
}
