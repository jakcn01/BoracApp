using AutoMapper;
using Business.Dtos.Recipe;
using Database;
using Database.Filters;

namespace Business.Services.Recipe;

public class RecipeService(IUnitOfWork _unitOfWork, IMapper _mapper) : IRecipeService
{
	public async Task<RecipeDto> GetByIdAsync(int id)
	{
		var recipe = await _unitOfWork.Recipes.GetByIdAsync(id);
		return _mapper.Map<RecipeDto>(recipe);
	}

	public async Task<IEnumerable<RecipeDto>> GetAllAsync()
	{
		var recipes = await _unitOfWork.Recipes.GetAllFilteredAsync(new RecipeFilter());
		return _mapper.Map<IEnumerable<RecipeDto>>(recipes);
	}

	public async Task<RecipeDto> CreateAsync(CreateRecipeDto request)
	{
		var recipe = _mapper.Map<Database.Models.Recipe>(request);
		await _unitOfWork.Recipes.CreateAsync(recipe);
		await _unitOfWork.SaveChangesAsync();
		return _mapper.Map<RecipeDto>(recipe);
	}

	public async Task UpdateAsync(int id, UpdateRecipeDto request)
	{
		var recipe = await _unitOfWork.Recipes.GetByIdAsync(id);
		_mapper.Map(request, recipe);
		await _unitOfWork.Recipes.UpdateAsync(recipe);
		await _unitOfWork.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		await _unitOfWork.Recipes.DeleteAsync(id);
		await _unitOfWork.SaveChangesAsync();
	}
}
