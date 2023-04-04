using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
namespace Biblioteca_API.DTOs.CreateUpdateObjects
{
    public class CreateUpdateMembers
    {
        [Key]
        [JsonIgnore]
        public Guid IDMembru { get; set; }
        public string NumeMembru { get; set; }
    }   
}
