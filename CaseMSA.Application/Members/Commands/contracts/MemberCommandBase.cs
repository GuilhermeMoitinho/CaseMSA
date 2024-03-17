using MediatR;

namespace CaseMSA.Application.Members.Commands.contracts
{
    public abstract class MemberCommandBase : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
    }
}
