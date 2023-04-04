using System.ComponentModel.DataAnnotations;

namespace Biblioteca_API.DTOs
{
    public class Member
    {
        [Key]
        public Guid IDMembru { get; set; }
        public string? NumeMembru { get; set; }
    }
}
