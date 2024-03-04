using Application.Dtos;
using Application.Services.Abstractions;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessageController : Controller
{
    private readonly IBaseCrudService<Message, MessageDto> _messageService;

    public MessageController(IBaseCrudService<Message, MessageDto> messageService)
    {
        _messageService = messageService;
    }
    
    [HttpPost]
    [Route(nameof(Create))]
    public async Task<ActionResult<MessageDto>> Create([FromBody] MessageDto dto)
    {
        var message = await _messageService.Add(dto);
        return Ok(message);
    }
    
    [HttpGet]
    [Route(nameof(GetById))]
    public async Task<ActionResult<MessageDto>>  GetById([FromQuery] Guid id)
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