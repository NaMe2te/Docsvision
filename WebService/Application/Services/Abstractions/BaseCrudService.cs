using System.Linq.Expressions;
using AutoMapper;
using DataAccess.DBContexts;
using DataAccess.Repositories;
using DataAccess.UnitOfWork;

namespace Application.Services.Abstractions;

public abstract class BaseCrudService<TEntity, TDto> : IBaseCrudService<TEntity, TDto>
    where TEntity : class
    where TDto : class
{
    protected readonly IBaseRepository<TEntity> _repository;
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;

    protected BaseCrudService(IBaseRepository<TEntity> repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<TDto> Add(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        entity = await _repository.Add(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<TDto>(entity);
    }

    public async Task<TDto> Update(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        entity = await _repository.Update(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<TDto>(entity);
    }

    public async Task<TDto> Remove(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        _repository.Delete(entity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<TDto>(entity);
    }

    public async Task<TDto> Get(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = await _repository.Get(predicate);
        return _mapper.Map<TDto>(entity);
    }

    public async Task<IEnumerable<TDto>> GetAll(Expression<Func<TEntity, bool>>? predicate = null)
    {
        var entities = await _repository.GetAll(predicate);
        return _mapper.Map<IEnumerable<TDto>>(entities);
    }
}