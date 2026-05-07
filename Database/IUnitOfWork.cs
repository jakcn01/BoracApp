using Database.Repositories.Recipe;

namespace Database;

public interface IUnitOfWork
{
	IRecipeRepository Recipes { get; }
	Task SaveChangesAsync();
}
