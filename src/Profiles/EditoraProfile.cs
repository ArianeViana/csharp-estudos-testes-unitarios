
using AutoMapper;
using cadastro_livros.Models.Dtos.Editora;
using cadastro_livros.Models.Entities;

namespace cadastro_livros.Profiles
{
    public class EditoraProfile : Profile
    {
        public EditoraProfile()
        {
            CreateMap<AddEditoraDto, Editora>();
            CreateMap<Editora, ReadEditoraDto>();
        }
    }
}