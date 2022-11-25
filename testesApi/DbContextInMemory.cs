using Microsoft.EntityFrameworkCore;
using cadastro_livros.Data;

namespace testesApi
{

    public class DbContextInMemory : AppDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "BancoTeste");
        }
    }
}