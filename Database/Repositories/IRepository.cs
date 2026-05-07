using Database.Filters._Shared;
using Database.Models._Shared;

namespace Database.Repositories;

public interface IRepository<T, F> where T : DatabaseModel where F : IRepositoryFilter<T>
{
	Task<T> GetByIdAsync(int id);
	Task<IEnumerable<T>> GetAllFilteredAsync(F filter);
	Task UpdateAsync(T model);
	Task CreateAsync(T model);
	Task DeleteAsync(int id);
}
