using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Kolokwium2Poprawa.Models;

[Table("Character_Title")]
public class Character_Title
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Character")]
    public int CharacterId { get; set; }
    [ForeignKey("Title")]
    public int TitleId { get; set; }
    public DateTime AcquiredAt { get; set; }
    
    public Character Character { get; set; }
    public Title Title { get; set; }
    
    
}