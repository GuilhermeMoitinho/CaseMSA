using CaseMSA.Domain.Entities;
using MediatR;

namespace CaseMSA.Application.Members.Queries
{
    public class GetMemberByIdQuery : IRequest<Member>
    {
        public Guid Id { get; set; }
    }
}
