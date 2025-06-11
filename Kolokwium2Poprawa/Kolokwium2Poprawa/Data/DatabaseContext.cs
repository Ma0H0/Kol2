using System.Runtime.Intrinsics.X86;
using Kolokwium2Poprawa.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2Poprawa.Data;

public class DatabaseContext: DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<Character_Title> Character_Titles { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>().HasData(new List<Character>()
        {
            new Character() { Id = 1, FirstName = "John", LastName = "Doe" ,CurrentWeight = 3,MaxWeight = 30},
            new Character() { Id = 2, FirstName = "Jane", LastName = "Doe" ,CurrentWeight = 3,MaxWeight = 20},
            new Character() { Id = 3, FirstName = "Julie", LastName = "Doe" ,CurrentWeight = 3,MaxWeight = 40},
        });
        modelBuilder.Entity<Item>().HasData(new List<Item>()
        {
            new Item() { Id = 1, Name = "Apple", Weight = 5 },
            new Item() { Id = 2, Name = "Sword", Weight = 5 },
            new Item() { Id = 3, Name = "Cactus", Weight = 5 },
        });
        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>()
        {
            new Backpack() { Id = 1, CharacterId = 1, ItemId = 1,Amount = 3},
            new Backpack() { Id = 2, CharacterId = 3, ItemId = 3,Amount = 2},
            new Backpack() { Id = 3, CharacterId = 2, ItemId = 2,Amount = 1},
   
        });
        modelBuilder.Entity<Title>().HasData(new List<Title>()
        {
            new Title() { Id = 1, Name = "Slayer"},
            new Title() { Id = 2, Name = "The Slayer"},
            new Title() { Id = 3, Name = "The The Slayer"},

        });
        modelBuilder.Entity<Character_Title>().HasData(new List<Character_Title>()
        {
            new Character_Title() { Id = 1, CharacterId = 1, TitleId = 1,AcquiredAt = DateTime.Parse("2025-05-01")},
            new Character_Title() { Id = 2, CharacterId = 2, TitleId = 2,AcquiredAt = DateTime.Parse("2025-05-02")},
            new Character_Title() { Id = 3, CharacterId = 3, TitleId = 3,AcquiredAt = DateTime.Parse("2025-05-03")},
          
        });
        
        
    }


}