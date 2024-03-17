using CaseMSA.Application.Members.Commands.contracts;
using CaseMSA.Domain.Entities;
using MediatR;

namespace CaseMSA.Application.Members.Commands
{
    public class CreateMemberCommand : IRequest<Member>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
    }
}
