using CaseMSA.Domain.Interfaces;
using MediatR;

namespace CaseMSA.Application.Members.Commands.Handlers
{
    public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand>
    {
        private readonly IMemberRepository _repository;
        private readonly IUnityOfWork _UoW;

        public UpdateMemberCommandHandler(IMemberRepository repository, IUnityOfWork uoW)
        {
            _repository = repository;
            _UoW = uoW;
        }

        public async Task Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var memberExisting = await _repository.GetMemberById(request.Id);
            
            if (memberExisting is null)
                throw new InvalidOperationException("Member not found");

            memberExisting.Update(request.FirstName,
                                  request.LastName,
                                  request.Gender,
                                  request.Email,
                                  request.IsActive);

            await _repository.UpdateMember(memberExisting);
            await _UoW.CommitAsync();
        }
    }
}
