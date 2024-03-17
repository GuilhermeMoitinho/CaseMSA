using CaseMSA.Domain.Entities.contracts;
using CaseMSA.Domain.Validation;
using System.Text.Json.Serialization;

namespace CaseMSA.Domain.Entities
{
    public sealed class Member : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public GenderEnum Gender { get; private set; }
        public string Email { get; private set; }
        public bool? IsActive { get; private set; }

        public Member(string firstName, 
                      string lastName,
                      GenderEnum gender, 
                      string email, 
                      bool? isActive)
        {
            Id = Guid.NewGuid();
            ValidateDomain(firstName, lastName, gender, email, isActive);
        }

        [JsonConstructor]
        public Member(Guid id, 
                      string firstname, 
                      string lastname,
                      GenderEnum gender, 
                      string email, 
                      bool? active)
        {
            DomainValidation.When(id == Guid.Empty, "Invalid Id value.");
            Id = id;
            ValidateDomain(firstname, lastname, gender, email, active);
        }

        public void Update(string firstName, 
                           string lastName,
                           GenderEnum gender, 
                           string email, 
                           bool? isActive)
        {
            ValidateDomain(firstName, lastName, gender, email, isActive);
        }

        private void ValidateDomain(string firstName, 
                                    string lastName,
                                    GenderEnum gender, 
                                    string email, 
                                    bool? isActive)
        {
            DomainValidation.When(string.IsNullOrEmpty(firstName),
            "Invalid name. FirstName is required");

            DomainValidation.When(firstName.Length < 3,
                "Invalid name, too short, minimum 3 characters");

            DomainValidation.When(string.IsNullOrEmpty(lastName),
                "Invalid lastname. LastName is required");

            DomainValidation.When(lastName.Length < 3,
                "Invalid lastname, too short, minimum 3 characters");

            DomainValidation.When(email?.Length > 250,
                "Invalid email, too long, maximum 250 characters");

            DomainValidation.When(email?.Length < 6,
                "Invalid email, too short, minimum 6 characters");

            DomainValidation.When(gender.Equals(null),
               "Invalid gender, Gender is required");

            DomainValidation.When(!isActive.HasValue,
                "Must define activity");

            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Email = email;
            IsActive = isActive;
        }
    }
}
