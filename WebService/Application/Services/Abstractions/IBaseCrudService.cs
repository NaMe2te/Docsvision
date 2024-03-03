using System.Linq.Expressions;

namespace Application.Services.Abstractions;

public interface IBaseCrudService<TEntity, TDto> 
    where TEntity : class
    where TDto : class
{
    Task<TDto> Add(TDto dto);
    Task<TDto> Update(TDto dto);
    Task<TDto> Remove(TDto dto);
    Task<TDto> Get(Expression<Func<TEntity, bool>> predicate);
    Task<IEnumerable<TDto>> GetAll(Expression<Func<TEntity, bool>>? predicate = null);
}