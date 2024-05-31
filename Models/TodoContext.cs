using Microsoft.EntityFrameworkCore;

namespace TokioMarineApiExample.Models;

public class TodoContext(DbContextOptions<TodoContext> options) : DbContext(options)
{
    public DbSet<TodoItem> TodoItems { get; set; } = null!;
}