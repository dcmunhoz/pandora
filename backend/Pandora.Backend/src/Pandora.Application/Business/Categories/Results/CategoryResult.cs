using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Application.Business.Categories.Results
{
    public record CategoryResult(Guid Id, string Description, Guid? ParentId, Guid UserCreationId);
}
