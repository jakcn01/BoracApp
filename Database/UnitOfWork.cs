using Database.Repositories.Recipe;

namespace Database;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
	public IRecipeRepository Recipes { get; } = new RecipeRepository(dbContext);

	public Task SaveChangesAsync() => dbContext.SaveChangesAsync();
}
