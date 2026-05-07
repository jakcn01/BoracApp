using Database.Models._Shared;

namespace Database.Filters._Shared;

public interface IRepositoryFilter<T> where T : DatabaseModel
{
	IQueryable<T> Apply(IQueryable<T> query);
}
