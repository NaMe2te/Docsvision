using Application.Dtos;
using Application.Services.Abstractions;
using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess.UnitOfWork;

namespace Application.Services;

public class MessageService : BaseCrudService<Message, MessageDto>,
    IMessageService
{
    public MessageService(IBaseRepository<Message> repository, IMapper mapper, IUnitOfWork unitOfWork)
        : base(repository, mapper, unitOfWork) { }


    public async Task<MessageDto> GetById(Guid id)
    {
        var message = await _repository.Get(m => m.Id == id);
        return _mapper.Map<MessageDto>(message);
    }
}