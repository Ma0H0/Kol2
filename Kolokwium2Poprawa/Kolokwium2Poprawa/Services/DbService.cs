using Kolokwium2Poprawa.Data;
using Kolokwium2Poprawa.DTOs;
using Kolokwium2Poprawa.Exceptions;
using Kolokwium2Poprawa.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2Poprawa.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<CharacterDTO> GetCharacter(int characterId)
    {
        var character = await _context.Characters
            .Select(e => new CharacterDTO
            { 
                Id = e.Id,
               FirstName = e.FirstName,
               LastName = e.LastName,
               CurrentWeight = e.CurrentWeight,
               MaxWeight = e.MaxWeight,
               BackpackItems = e.Backpacks.Select(e => new BackbackDTO()
               {
                   ItemName = e.Item.Name,
                   ItemWeight = e.Item.Weight,
                   Amount = e.Amount
               }).ToList(),
               Titles = e.Titles.Select(e => new TitleDTO()
               {
                   Title = e.Title.Name,
                   AquiredAt = e.AcquiredAt
               }).ToList()
            })
            .FirstOrDefaultAsync(e => e.Id == characterId);
        if (character == null)
            throw new NotFoundException( $"Character with Id {characterId} not found");
        return character;

    }

    public async Task<ItemDTO> AddItems(ItemDTO itemDto,int id)
    {
        foreach (var item in itemDto.ItemsId)
        {
            var back = new Backpack
            {
                CharacterId = id,
                ItemId = item.Id,
                Amount = 1
            };
            _context.Backpacks.Add(back);
            await _context.SaveChangesAsync();

        }
        return itemDto;
    }
}
