using Business.Dtos.Recipe;

namespace Business.Services.Recipe;

public interface IRecipeService : IService<RecipeDto, CreateRecipeDto, UpdateRecipeDto>
{
}
