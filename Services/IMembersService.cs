using Biblioteca_API.DTOs.CreateUpdateObjects;
using Biblioteca_API.DTOs;

namespace Biblioteca_API.Services
{
    public interface IMembersService
    {
        public Task<IEnumerable<Member>> GetMembersAsync();
        public Task<Member> GetMembersByIdAsync(Guid id);
        public Task CreateMembersAsync(Member newmember);
        public Task<bool> DeleteMembersAsync(Guid id);
        public Task<CreateUpdateMembers> UpdateMembersAsync(Guid id, CreateUpdateMembers members);
        public Task<CreateUpdateMembers> UpdatePartiallyMembersAsync(Guid id, CreateUpdateMembers members);
    }
}
