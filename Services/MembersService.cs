using Biblioteca_API.DTOs.CreateUpdateObjects;
using Biblioteca_API.DTOs;
using Biblioteca_API.Helpers;
using Biblioteca_API.Repositories;


namespace Biblioteca_API.Services
{
    public class MembersService : IMembersService
    {
        private readonly IMembersRepository _repository;
        public MembersService(IMembersRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Member>> GetMembersAsync()
        {
            return await _repository.GetMembersAsync();
        }
        public async Task<Member> GetMembersByIdAsync(Guid id)
        {
            return await _repository.GetMembersByIdAsync(id);
        }
        public async Task CreateMembersAsync(Member newmembers)
        {
            //ValidationFunctions.ExceptionsWhenDateIsNotValid(newmembers.IDCarte, newmembers.Imprumutata);
            await _repository.CreateMembersAsync(newmembers);
        }
        public async Task<bool> DeleteMembersAsync(Guid id)
        {
            return await _repository.DeleteMembersAsync(id);
        }
        public async Task<CreateUpdateMembers> UpdateMembersAsync(Guid id, CreateUpdateMembers members)
        {
            //ValidationFunctions.ExceptionsWhenDateIsNotValid(members.IDCarte, members.Imprumutata);
            return await _repository.UpdateMembersAsync(id, members);
        }
        public async Task<CreateUpdateMembers> UpdatePartiallyMembersAsync(Guid id, CreateUpdateMembers members)
        {
            //ValidationFunctions.ExceptionsWhenDateIsNotValid(members.IDCarte, members.Imprumutata);
            return await (_repository.UpdatePartiallyMembersAsync(id, members));
        }
    }
}
