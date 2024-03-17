using CaseMSA.Domain.Entities;
using CaseMSA.Domain.Interfaces;
using CaseMSA.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CaseMSA.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        protected readonly AppDbcontext db;

        public MemberRepository(AppDbcontext db)
        => this.db = db;
            
        

        public async Task<Member> AddMember(Member member)
        {
            if(member is null)
                    throw new ArgumentNullException(nameof(member));

            var memberCreate = await db.Members.AddAsync(member);

            return memberCreate.Entity;
        }

        public async Task DeleteMember(Guid id)
        {
            var member = await GetMemberById(id);

            if (member is null)
                throw new InvalidOperationException("Member not found");

            db.Members.Remove(member);
        }

        public async Task<Member> GetMemberById(Guid id)
        {
            var member = await db.Members.FindAsync(id);

            if (member is null)
                throw new InvalidOperationException("Member not found");

            return member;
        }

        public async Task<IEnumerable<Member>> GetMembers(int skip, int take)
        {
            var memberlist = await db.Members.AsNoTracking()
                                             .Skip(skip)
                                             .Take(take)
                                             .ToListAsync();
            return memberlist ?? Enumerable.Empty<Member>();
        }

        public async Task UpdateMember(Member member)
        {
            if (member is null)
                throw new ArgumentNullException(nameof(member));

            db.Members.Update(member);
        }
    }
}
