using Pandora.Application.Common.Interfaces.Repository;
using Pandora.Domain.Entities;
using Pandora.Infra.Repository.Context;

namespace Pandora.Infra.Persistence.Repository
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Category> AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }
    }
}
