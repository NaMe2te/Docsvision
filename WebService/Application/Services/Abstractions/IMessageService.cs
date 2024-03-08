using System.Linq.Expressions;
using Application.Dtos;
using DataAccess.Entities;

namespace Application.Services.Abstractions;

public interface IMessageService
{
    Task<MessageWithProfilsDto> Add(MessageDto messageDto);
    Task<MessageWithProfilsDto> Get(Expression<Func<Message, bool>> predicate);
    Task<IEnumerable<MessageWithProfilsDto>> GetAll(Expression<Func<Message, bool>>? predicate = null);
}