using CaseMSA.Domain.Entities;

namespace CaseMSA.Domain.Interfaces
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetMembers(int skip, int take);
        Task<Member> GetMemberById(Guid id);
        Task<Member> AddMember(Member member);
        Task UpdateMember(Member member);
        Task DeleteMember(Guid id);
    }
}
