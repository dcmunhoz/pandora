using MediatR;
using Pandora.Application.Business.Categories.Results;

namespace Pandora.Application.Business.Categories.Commands
{
    public record CreateCategoryCommand(string Description, string? ParentId, string UserCreationId): IRequest<CategoryResult>;
}
