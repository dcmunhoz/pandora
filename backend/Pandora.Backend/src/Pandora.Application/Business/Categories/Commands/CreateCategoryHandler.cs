using MediatR;
using Pandora.Application.Business.Categories.Results;
using Pandora.Application.Common.Interfaces.Repository;
using Pandora.Domain.Entities;

namespace Pandora.Application.Business.Categories.Commands
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryResult>
    {

        private ICategoryRepository _categoryRespository;

        public CreateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRespository = categoryRepository;
        }

        public async Task<CategoryResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            _categoryRespository.BeginTransaction();
            // TODO: Extract id of user creation from token
            // TODO: Verify if exists category + parent already created

            Category category = request.MapTo<Category>();

            await _categoryRespository.AddAsync(category);

            return category.MapTo<CategoryResult>();

        }
    }
}
