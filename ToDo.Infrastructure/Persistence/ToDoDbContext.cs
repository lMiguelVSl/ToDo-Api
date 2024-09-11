using Microsoft.EntityFrameworkCore;
using Entities_ToDo = ToDo.Core.Entities.ToDo;

namespace ToDo.Infrastructure.Persistence;

public class ToDoDbContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=ToDoApp;user id=SA;password=MyStrongPass123;encrypt=False");
    }
    
    public DbSet<Entities_ToDo>? ToDos { get; set; }
}