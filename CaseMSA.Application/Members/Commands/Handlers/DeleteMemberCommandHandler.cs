using CaseMSA.Domain.Interfaces;
using MediatR;

namespace CaseMSA.Application.Members.Commands.Handlers
{
    public class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand>
    {
        private readonly IMemberRepository _repository;
        private readonly IUnityOfWork _UoW;

        public DeleteMemberCommandHandler(IMemberRepository repository, IUnityOfWork uoW)
        {
            _repository = repository;
            _UoW = uoW;
        }

        public async Task Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
        {
            var MemberExisting = _repository.GetMemberById(request.Id);

            if (MemberExisting is null)
                throw new InvalidOperationException("Member not found");

            await _repository.DeleteMember(request.Id);
            await _UoW.CommitAsync();
            
        }
    }
}
