using MediatR;

namespace CaseMSA.Application.Members.Commands
{
    public class DeleteMemberCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
