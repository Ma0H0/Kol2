using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2Poprawa.Models;

[Table("Item")]
public class Item
{
    [Key]
    public int Id { get; set; }
    public String Name { get; set; }
    public int Weight { get; set; }
    
    public ICollection<Backpack> Backpacks { get; set; }
    
}