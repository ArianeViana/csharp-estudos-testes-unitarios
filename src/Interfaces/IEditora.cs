using cadastro_livros.Models.Dtos.Editora;

namespace cadastro_livros.Interfaces
{
    public interface IEditora : IBase<AddEditoraDto, ReadEditoraDto>, IUpdate<UpdateEditoraDto, ReadEditoraDto>
    {
        IEnumerable<ReadEditoraDto> BuscarPorNomeEditora(string nomeEditora);

    }
}