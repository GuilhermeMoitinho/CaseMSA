using CaseMSA.Domain.Entities;
using MediatR;

namespace CaseMSA.Application.Members.Queries
{
    public class GetMembersQuery : IRequest<IEnumerable<Member>>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
