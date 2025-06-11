using Kolokwium2Poprawa.DTOs;

namespace Kolokwium2Poprawa.Services;

public interface IDbService
{
    Task<CharacterDTO> GetCharacter (int characterId);
    Task<ItemDTO> AddItems (ItemDTO itemDto,int id);
    
}