using CaseMSA.Domain.Entities;
using CaseMSA.Domain.Interfaces;
using MediatR;
namespace CaseMSA.Application.Members.Commands.Handlers
{
    internal class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand>
    {
        private readonly IMemberRepository _repository;
        private IUnityOfWork _UoW;

        public CreateMemberCommandHandler(IMemberRepository repository, IUnityOfWork uoW)
        {
            _repository = repository;
            _UoW = uoW;
        }

        public async Task Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var newMember = new Member(request.FirstName,
                                       request.LastName,
                                       request.Gender,
                                       request.Email,
                                       request.IsActive);

            await _repository.AddMember(newMember);
            await _UoW.CommitAsync();
        }
    }
}
