using Database.Filters;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories.Recipe;

using Recipe = Models.Recipe;

public class RecipeRepository(AppDbContext dbContext) : IRecipeRepository
{
	public Task CreateAsync(Recipe model)
	{
		dbContext.Recipes.Add(model);
		return Task.CompletedTask;
	}

	public async Task DeleteAsync(int id)
	{
		var recipe = await dbContext.Recipes.FindAsync(id)
			?? throw new KeyNotFoundException($"Recipe with id {id} was not found.");

		dbContext.Recipes.Remove(recipe);
	}

	public async Task<IEnumerable<Recipe>> GetAllFilteredAsync(RecipeFilter filter)
	{
		var query = dbContext.Recipes.AsQueryable();
		query = filter.Apply(query);
		return await query.ToListAsync();
	}

	public async Task<Recipe> GetByIdAsync(int id)
	{
		return await dbContext.Recipes.FindAsync(id)
			?? throw new KeyNotFoundException($"Recipe with id {id} was not found.");
	}

	public Task UpdateAsync(Recipe model)
	{
		dbContext.Recipes.Update(model);
		return Task.CompletedTask;
	}
}
