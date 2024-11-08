using MeusLivros.Domain.Entities;
using MeusLivros.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace MeusLivros.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<Editora> Editoras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EditoraMap());
        }
    }
}