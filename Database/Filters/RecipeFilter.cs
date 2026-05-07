using Database.Filters._Shared;
using Database.Models;

namespace Database.Filters;

public class RecipeFilter : IRepositoryFilter<Recipe>
{
    public string? Name { get; set; }

    public IQueryable<Recipe> Apply(IQueryable<Recipe> query)
    {
        if (!string.IsNullOrWhiteSpace(Name))
            query = query.Where(r => r.Name.Contains(Name));

        return query;
    }
}
