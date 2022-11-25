using cadastro_livros.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace cadastro_livros.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Editora> Editoras { get; set; }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);

            Builder.Entity<Livro>()
            .HasOne(livro => livro.Autor)
            .WithMany(autor => autor.Livros)
            .HasForeignKey(livro => livro.AutorId);

            Builder.Entity<Livro>()
            .HasOne(livro => livro.Editora)
            .WithMany(editora => editora.Livros)
            .HasForeignKey(livro => livro.EditoraId);
        }

    }

}