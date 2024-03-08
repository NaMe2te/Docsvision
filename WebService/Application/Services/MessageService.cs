using System.Linq.Expressions;
using Application.Dtos;
using Application.Services.Abstractions;
using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess.UnitOfWork;

namespace Application.Services;

public class MessageService : IMessageService
{
    private readonly IBaseRepository<Message> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MessageService(IBaseRepository<Message> repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<MessageWithProfilsDto> Add(MessageDto messageDto)
    {
        var message = _mapper.Map<Message>(messageDto);
        message = await _repository.Add(message);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<MessageWithProfilsDto>(message);
    }
    
    public async Task<MessageWithProfilsDto> Get(Expression<Func<Message, bool>> predicate)
    {
        var message = await _repository.Get(predicate);
        return _mapper.Map<MessageWithProfilsDto>(message);
    }

    public async Task<IEnumerable<MessageWithProfilsDto>> GetAll(Expression<Func<Message, bool>>? predicate = null)
    {
        var messages = await _repository.GetAll(predicate);
        return _mapper.Map<IEnumerable<MessageWithProfilsDto>>(messages);
    }
}