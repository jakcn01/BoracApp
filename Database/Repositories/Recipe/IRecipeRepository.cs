using Database.Filters;
using Database.Filters;

namespace Database.Repositories.Recipe;

public interface IRecipeRepository : IRepository<Models.Recipe, RecipeFilter>
{
}
