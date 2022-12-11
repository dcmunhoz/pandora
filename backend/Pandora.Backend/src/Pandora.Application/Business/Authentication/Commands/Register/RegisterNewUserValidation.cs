using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Application.Business.Authentication.Commands.Register
{
    public class RegisterNewUserValidation: AbstractValidator<RegisterNewUserCommand>
    {
        public RegisterNewUserValidation()
        {
            RuleFor(p => p.Username)
                .NotNull()
                .NotEmpty()
                .WithMessage("O usuário deve ser informado.");

            RuleFor(p => p.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("A senha deve ser informada.");

            RuleFor(p => p.ConfirmedPassword)
                .NotNull().NotEmpty().WithMessage("A Confirmação de senha deve ser informada.")
                .Equal(p => p.Password).WithMessage("As senhas devem ser iguais");

            RuleFor(p => p.Email)
                .NotNull().NotEmpty().WithMessage("O E-mail deve ser informado.");

            RuleFor(p => p.Name)
                .NotNull().NotEmpty().WithMessage("O Nome deve ser informado.");

            RuleFor(p => p.LastName)
                .NotNull().NotEmpty().WithMessage("O Sobrenome deve ser informado.");
        }
    }
}
