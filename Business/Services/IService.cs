namespace Business.Services;

public interface IService<TDto, TCreateDto, TUpdateDto>
{
	Task<TDto> GetByIdAsync(int id);
	Task<IEnumerable<TDto>> GetAllAsync();
	Task<TDto> CreateAsync(TCreateDto request);
	Task UpdateAsync(int id, TUpdateDto request);
	Task DeleteAsync(int id);
}
