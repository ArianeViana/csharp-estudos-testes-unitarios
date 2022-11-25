using cadastro_livros.Data;
using cadastro_livros.Exceptions.Interfaces;
using FluentResults;

namespace cadastro_livros.Exceptions
{
    public class EditoraException : IEditoraException
    {
        private readonly AppDbContext _context;

        public EditoraException(AppDbContext context)
        {
            _context = context;
        }
        public Result EditoraJaCadastrada(string nomeEditora)
        {
            var editora = _context.Editoras.FirstOrDefault(editora => editora.Nome == nomeEditora);

            if (editora != null)
            {
                return Result.Fail("Editora já cadastrada.");
            }

            return Result.Ok();
        }
    }
}