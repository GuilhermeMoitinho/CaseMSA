using CaseMSA.Domain.Entities;

namespace CaseMSA.Application.DTOs.ViewModel
{
    public class MemberViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }

        public MemberViewModel(Guid id, 
                               string firstName, 
                               string lastName,
                               string email,
                               GenderEnum gender,
                               bool? isActive)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Email = email;
            IsActive = isActive;
        }
    }
}
