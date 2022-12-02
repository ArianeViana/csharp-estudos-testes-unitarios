using FluentResults;

namespace cadastro_livros.Exceptions.Interfaces
{
    public interface ILivroException
    {
        Result LivroJaCadastrado(string isbn13);
    }
}