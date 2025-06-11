using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2Poprawa.Models;

[Table("Character")]
public class Character
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    
    public ICollection<Backpack> Backpacks { get; set; }
    public ICollection<Character_Title> Titles { get; set; }
    
}