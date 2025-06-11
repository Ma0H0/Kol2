namespace Kolokwium2Poprawa.DTOs;

public class CharacterDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    public List<BackbackDTO> BackpackItems { get; set; }
    public List<TitleDTO> Titles { get; set; }
    
}

public class BackbackDTO
{
    public String ItemName { get; set; }
    public int ItemWeight { get; set; }
    public int Amount { get; set; }
}

public class TitleDTO
{
    public String Title { get; set; }
    public DateTime AquiredAt { get; set; }
}