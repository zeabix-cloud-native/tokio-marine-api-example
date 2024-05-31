using Microsoft.EntityFrameworkCore;

namespace TokioMarinApiExample.Models;

public class TodoContext(DbContextOptions<TodoContext> options) : DbContext(options)
{
    public DbSet<TodoItem> TodoItems { get; set; } = null!;
}