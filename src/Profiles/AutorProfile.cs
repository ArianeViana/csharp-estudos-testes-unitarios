using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using cadastro_livros.Models.Dtos.Autor;
using cadastro_livros.Models.Entities;

namespace cadastro_livros.Profiles
{
    public class AutorProfile : Profile
    {
        public AutorProfile()
        {
            CreateMap<AddAutorDto, Autor>();
            CreateMap<Autor, ReadAutorDto>();
            CreateMap<UpdateAutorDto, Autor>();
        }

    }
}