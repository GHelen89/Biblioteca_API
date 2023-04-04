using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca_API.DTOs.CreateUpdateObjects
{
    public class CreateUpdateBooks
    {
        [Key]
        [JsonIgnore]
        public Guid  IDCarte { get; set; }
        public string NumeCarte { get; set; }
        public string Autor { get; set; }
        public string Editura { get; set; }
        public DateTime AnAparitie { get; set; }
        public Guid Imprumutata { get; set; }

    }
}
