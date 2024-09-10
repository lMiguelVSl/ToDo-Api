using Microsoft.EntityFrameworkCore;
using Models = ToDo.Core.Models;

namespace ToDo.Infrastructure.Persistence;

public class ToDoDbContext(DbContextOptions<ToDoDbContext> options) : DbContext(options)
{
    public required DbSet<Models.ToDo> ToDos { get; set; }
}   