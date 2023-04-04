using System.ComponentModel.DataAnnotations;

namespace Biblioteca_API.DTOs
{
    public class Category
    {
        [Key]
        public Guid IDCategorie { get; set; }
        public string NumeCategorie { get; set; }
        public string Descriere { get; set; }
    }
}
