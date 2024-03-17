using CaseMSA.Application.Members.Commands.contracts;

namespace CaseMSA.Application.Members.Commands
{
    public class UpdateMemberCommand : MemberCommandBase
    {
        public Guid Id { get; set; }
    }
}
