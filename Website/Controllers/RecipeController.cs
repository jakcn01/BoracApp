using Business.Dtos.Recipe;
using Business.Services.Recipe;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipeController(IRecipeService recipeService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RecipeDto>>> GetAll()
    {
        var recipes = await recipeService.GetAllAsync();
        return Ok(recipes);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<RecipeDto>> GetById(int id)
    {
        try
        {
            var recipe = await recipeService.GetByIdAsync(id);
            return Ok(recipe);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult<RecipeDto>> Create(CreateRecipeDto request)
    {
        var created = await recipeService.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateRecipeDto request)
    {
        try
        {
            await recipeService.UpdateAsync(id, request);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await recipeService.DeleteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
