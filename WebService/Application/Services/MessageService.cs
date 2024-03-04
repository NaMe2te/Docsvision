using Application.Dtos;
using Application.Services.Abstractions;
using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess.UnitOfWork;

namespace Application.Services;

public class MessageService : BaseCrudService<Message, MessageDto>
{
    public MessageService(IBaseRepository<Message> repository, IMapper mapper, IUnitOfWork unitOfWork)
        : base(repository, mapper, unitOfWork) { }
}