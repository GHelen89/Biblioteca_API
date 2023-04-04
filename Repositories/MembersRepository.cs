using AutoMapper;
using Biblioteca_API.DataContext;
using Biblioteca_API.DTOs;
using Microsoft.EntityFrameworkCore;
using Biblioteca_API.DTOs.CreateUpdateObjects;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca_API.Repositories
{
    public class MembersRepository : IMembersRepository
    {
        private readonly BibliotecaDBDataContext _context;
        private readonly IMapper _mapper;
        public MembersRepository(BibliotecaDBDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Member>> GetMembersAsync()
        {
            return await _context.Members.ToListAsync();

        }
        public async Task<Member> GetMembersByIdAsync(Guid id)
        {
            return await _context.Members.SingleOrDefaultAsync(a => a.IDMembru == id);
        }
        public async Task CreateMembersAsync(Member members)
        {
            members.IDMembru = Guid.NewGuid();
            _context.Members.Add(members);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteMembersAsync(Guid id)
        {
            Member members = await GetMembersByIdAsync(id);
            if (members == null)
            {
                return false;
            }
            _context.Members.Remove(members);
            await _context.SaveChangesAsync();
            return true;


        }
        public async Task<CreateUpdateMembers> UpdateMembersAsync(Guid id, CreateUpdateMembers members)
        {
            if (!await ExistMembersAsync(id))
            {
                return null;
            }
            var membersUpdated = _mapper.Map<Member>(members);
            membersUpdated.IDMembru = id;
            _context.Update(membersUpdated);
            await _context.SaveChangesAsync();
            return members;
        }
        private async Task<bool> ExistMembersAsync(Guid id)
        {
            return await _context.Members.CountAsync(a => a.IDMembru == id) > 0;
        }
        public async Task<CreateUpdateMembers> UpdatePartiallyMembersAsync(Guid id, CreateUpdateMembers members)
        {
            var memberFromDB = await GetMembersByIdAsync(id);
            if (memberFromDB == null) { return null; }
            if (members.IDMembru != null && members.IDMembru != memberFromDB.IDMembru)
            {
                memberFromDB.IDMembru = members.IDMembru;
            }
            if (members.NumeMembru != null && members.NumeMembru != memberFromDB.NumeMembru)
            {
                memberFromDB.NumeMembru = members.NumeMembru;
            }
          
            _context.Members.Update(memberFromDB);
            await _context.SaveChangesAsync();
            return members;
        }

    }
}
