using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Biblioteca_API.DTOs.CreateUpdateObjects
{
    public class CreateUpdateBookLoans
    {
        public DateTime DataImprumut { get; set; }
        public DateTime DataRetur { get; set; }
        public Guid IDMembru { get; set; }
        [Key]
        [JsonIgnore]
        public Guid IDImprumut { get; set; }
        public Guid IDCarte { get; set; }

    }
}
