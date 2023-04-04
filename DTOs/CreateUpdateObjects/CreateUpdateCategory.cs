using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
namespace Biblioteca_API.DTOs.CreateUpdateObjects
{
    public class CreateUpdateCategory
    {
        [Key]
        [JsonIgnore]
        public Guid IDCategorie { get; set; }
        public string NumeCategorie { get; set; }
        public string Descriere { get; set; }
       
    }
}
