using Application.Dtos;
using DataAccess.Entities;

namespace Application.Services.Abstractions;

public interface IMessageService : IBaseCrudService<Message, MessageDto>
{
    Task<MessageDto> GetById(Guid id);
}