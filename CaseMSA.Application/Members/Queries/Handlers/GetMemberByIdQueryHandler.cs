using CaseMSA.Domain.Entities;
using CaseMSA.Domain.Interfaces;
using MediatR;

namespace CaseMSA.Application.Members.Queries.Handlers
{
    public class GetMemberByIdQueryHandler : IRequestHandler<GetMemberByIdQuery, Member>
    {
        private readonly IMemberRepository _repository;

        public GetMemberByIdQueryHandler(IMemberRepository repository)
        {
            _repository = repository;
        }

        public async Task<Member> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
        {
            var memberExisting = await _repository.GetMemberById(request.Id);

            if (memberExisting is null)
                throw new InvalidOperationException("Member Not Found.");

            return memberExisting;
        }
    }
}
