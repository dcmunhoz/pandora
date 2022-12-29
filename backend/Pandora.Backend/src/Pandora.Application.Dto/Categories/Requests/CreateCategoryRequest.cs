namespace Pandora.Application.Dto.Category.Requests
{
    public record CreateCategoryRequest(string Description, string? ParentId);
}
