
using FluentResults;

namespace cadastro_livros.Exceptions.Interfaces
{
    public interface IEditoraException
    {
        Result EditoraJaCadastrada(string nomeEditora);
    }
}