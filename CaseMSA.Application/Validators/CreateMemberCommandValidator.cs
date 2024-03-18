using CaseMSA.Application.Members.Commands;
using FluentValidation;
using System.Data;

namespace CaseMSA.Application.Validators
{
    public class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
    {
        public CreateMemberCommandValidator()
        {
            RuleFor(m => m.FirstName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100)
                .WithMessage("O nome é obrigatório!")
                .OverridePropertyName("Primeiro nome");

            RuleFor(m => m.LastName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100)
                .WithMessage("O sobrenome é obrigatório!")
                .OverridePropertyName("Sobrenome");
                
            RuleFor(m => m.Email)
                .NotEmpty()
                .NotNull()
                .MaximumLength(150)
                .EmailAddress()
                .WithMessage("O email é obrigatório!")
                .OverridePropertyName("Email");

            RuleFor(m => m.IsActive)
                .NotEmpty()
                .NotNull()
                .WithMessage("Está propriedade é obrigatória!")
                .OverridePropertyName("Ativo");
        }
    }
}
