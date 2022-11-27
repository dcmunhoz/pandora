using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Application.Business.Example.Command.New
{
    public class AddTestValidation : AbstractValidator<AddTestCommand>
    {
        public AddTestValidation()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .MinimumLength(16);
        }
    }
}
