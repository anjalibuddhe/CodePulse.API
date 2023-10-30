using CodePulse.API.Models.Domain;
using CodePulse.API.Repositories.Implementation;
using CodePulse.API.Repositories.Interface;
using CodePulse.API.Services.Interface;
using System.Threading.Tasks;

namespace CodePulse.API.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repo;

        public CategoryService(ICategoryRepository repo)
        {
            this.repo = repo;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            return await repo.CreateAsync(category);
        }

        public Task<Category?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()

        {
            return await repo.GetAllAsync();
        }

        public Task<Category?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> UpdateAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
