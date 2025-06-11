using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Kolokwium2Poprawa.Models;

[Table("Title")]
public class Title
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<Character_Title> Title_Characters { get; set; }
    
}