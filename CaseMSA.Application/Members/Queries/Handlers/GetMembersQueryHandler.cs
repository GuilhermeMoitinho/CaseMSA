using CaseMSA.Domain.Entities;
using CaseMSA.Domain.Interfaces;
using MediatR;

namespace CaseMSA.Application.Members.Queries.Handlers
{
    public class GetMembersQueryHandler : IRequestHandler<GetMembersQuery, IEnumerable<Member>>
    {
        private readonly IMemberRepository _repository;

        public GetMembersQueryHandler(IMemberRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Member>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
        {
            var allMembers = await _repository.GetMembers(request.Skip, request.Take);

            return allMembers;
        }
    }
}
