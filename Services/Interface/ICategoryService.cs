﻿using CodePulse.API.Models.Domain;

namespace CodePulse.API.Services.Interface
{
    public interface ICategoryService
    {
        Task<Category> CreateAsync(Category category);

        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category?> GetById(Guid id);

        Task<Category?> UpdateAsync(Category category);

        Task<Category?> DeleteAsync(Guid id);
    }
}
