using AutoMapper;
using Business.Dtos.Recipe;
using Database.Models;

namespace Business.Profiles;

public class RecipeProfile : Profile
{
	public RecipeProfile()
	{
		CreateMap<Recipe, RecipeDto>();
		CreateMap<CreateRecipeDto, Recipe>();
		CreateMap<UpdateRecipeDto, Recipe>();
	}
}
