using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.Context
{
    public class TodosContext : DbContext
    {
        public TodosContext(DbContextOptions<TodosContext> dbContextOptions) : base(dbContextOptions) { }

        DbSet<Todos>? Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
