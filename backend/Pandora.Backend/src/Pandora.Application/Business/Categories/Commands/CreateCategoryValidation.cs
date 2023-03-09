using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Application.Business.Categories.Commands
{
    public class CreateCategoryValidation: AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidation()
        {
            RuleFor(p => p.Description)
                .NotNull().NotEmpty().WithMessage("Descrição não pode ser vazia!")
                .MaximumLength(16).WithMessage("Descrição não pode ter mais que 16 caracteres!");
                
        }
    }
}
