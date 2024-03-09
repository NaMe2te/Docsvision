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
    private readonly ILogger _logger;

    public MessageController(IMessageService messageService, ILogger<MessageController> logger)
    {
        _messageService = messageService;
        _logger = logger;
    }
    
    [HttpPost]
    [Route(nameof(Create))]
    public async Task<ActionResult<MessageWithProfilsDto>> Create([FromBody] MessageDto messageDto)
    {
        try
        {
            MessageWithProfilsDto message = await _messageService.Add(messageDto);
            _logger.LogInformation("Successfully have added {MessageId} messages", message.Id);
            return Ok(message);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred in Create method");
            return StatusCode(500);
        }
    }
    
    [HttpGet]
    [Route(nameof(GetById))]
    public async Task<ActionResult<MessageWithProfilsDto>> GetById([FromQuery] Guid id)
    {
        try
        {
            var message = await _messageService.Get(m => m.Id == id);
            _logger.LogInformation("Successfully have returned {MessageId} message", message.Id);
            return Ok(message);
        }
        catch (ArgumentNullException e)
        {
            _logger.LogError(e, e.Message);
            return NotFound(e.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in GetById method");
            return StatusCode(500);
        }
    }
    
    [HttpGet]
    [Route(nameof(GetAll))]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll()
    {
        try
        {
            var messages = await _messageService.GetAll();
            _logger.LogInformation("Successfully retrieved {MessageCount} messages", messages.Count());
            return Ok(messages);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in GetAll method");
            return StatusCode(500);
        }
    }
}