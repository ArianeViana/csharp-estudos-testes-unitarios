using FluentResults;

namespace cadastro_livros.Exceptions.Interfaces
{
    public interface IAutorException
    {
        Result AutorJaCadastrado(string nomeAutor);
    }
}