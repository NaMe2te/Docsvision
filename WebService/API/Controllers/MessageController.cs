using Application.Dtos;
using Application.Services.Abstractions;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class MessageController : Controller
{
    private readonly IMessageService _messageService;

    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }
    
    [HttpPost]
    [Route(nameof(Create))]
    public async Task<ActionResult<MessageWithProfilsDto>> Create([FromBody] MessageDto messageDto)
    {
        MessageWithProfilsDto message = await _messageService.Add(messageDto);
        return Ok(message);
    }
    
    [HttpGet]
    [Route(nameof(GetById))]
    public async Task<ActionResult<MessageWithProfilsDto>> GetById([FromQuery] Guid id)
    {
        var message = await _messageService.Get(m => m.Id == id);
        return Ok(message);
    }
    
    [HttpGet]
    [Route(nameof(GetAll))]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll()
    {
        var messages = await _messageService.GetAll();
        return Ok(messages);
    }
}