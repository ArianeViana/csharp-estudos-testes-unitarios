
using cadastro_livros.Models.Dtos.Livro;

namespace cadastro_livros.Interfaces
{
    public interface ILivro : IBase<AddLivroDto, ReadLivroDto>, IUpdate<UpdateLivroDto, ReadLivroDto>
    {

    }
}