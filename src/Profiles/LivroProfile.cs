using AutoMapper;
using cadastro_livros.Models.Dtos.Livro;
using cadastro_livros.Models.Entities;

namespace cadastro_livros.Profiles
{
    public class LivroProfile : Profile
    {
        public LivroProfile()
        {
            CreateMap<AddLivroDto, Livro>();
            CreateMap<Livro, ReadLivroDto>();
            CreateMap<UpdateLivroDto, Livro>();

        }
    }
}