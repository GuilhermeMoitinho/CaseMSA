using CaseMSA.Application.DTOs.ViewModel;
using CaseMSA.Domain.Entities;

namespace CaseMSA.Application.DTOs.Extensions
{
    public static class ExtensionsViewModel
    {
        public static MemberViewModel TransformInViewModel(this Member member)
        {
            var viewModel = new MemberViewModel(member.Id, 
                                                member.FirstName, 
                                                member.LastName, 
                                                member.Email,
                                                member.Gender, 
                                                member.IsActive);

            return viewModel;
        }

        public static IEnumerable<MemberViewModel> TranformInListViewModel(this IEnumerable<Member> member)
        {
           return member.Select(m => m.TransformInViewModel()).ToList();
        }
    }
}
