using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2Poprawa.Models;

[Table("Backpack")]
public class Backpack
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Item")]
    public int ItemId { get; set; }
    [ForeignKey("Character")]
    public int CharacterId { get; set; }
    public int Amount { get; set; }
    
    public Item Item { get; set; }
    public Character Character { get; set; }
    
}