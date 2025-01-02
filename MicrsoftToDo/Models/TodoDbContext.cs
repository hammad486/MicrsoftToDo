using Microsoft.EntityFrameworkCore;

namespace MicrsoftToDo.Models
{
    public class TodoDbContext:DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options): base(options)
        {
        }
        public DbSet<TodoItem> TodoItems { get; set; }
       
    }
}
