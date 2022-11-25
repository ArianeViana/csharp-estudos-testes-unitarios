using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cadastro_livros.Models.Dtos.Autor;
using FluentResults;

namespace cadastro_livros.Interfaces
{
    public interface IAutor : IBase<AddAutorDto, ReadAutorDto>
    {

    }
}