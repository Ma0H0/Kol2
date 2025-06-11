using Kolokwium2Poprawa.DTOs;
using Kolokwium2Poprawa.Exceptions;
using Kolokwium2Poprawa.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2Poprawa.Controllers;
[ApiController]
[Route("api/characters")]
public class CharacterController : ControllerBase
{
    private readonly IDbService _dbService;

    public CharacterController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCharacter(int id)
    {
        try
        {
            var character = await _dbService.GetCharacter(id);
            return Ok(character);
        }
        catch (NotFoundException e)
        {
            return NotFound();
        }
        
    }

    [HttpPost("/{id}/backpacks")]
    public async Task<IActionResult> AddItems(int id, ItemDTO itemDto)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid input data.");
        
     
        return Created("",await _dbService.AddItems(itemDto,id));  
    }
    
    
}