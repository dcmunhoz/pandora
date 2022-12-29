using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Application.Dto.Category.Responses
{
    public record CreateCategoryResponse(Guid Id, string Description, Guid? ParentId, Guid UserCreationId);
}
