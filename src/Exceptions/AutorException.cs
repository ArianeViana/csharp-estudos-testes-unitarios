using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cadastro_livros.Data;
using cadastro_livros.Exceptions.Interfaces;
using FluentResults;

namespace cadastro_livros.Exceptions
{
    public class AutorException : IAutorException
    {
        public readonly AppDbContext _context;

        public AutorException(AppDbContext context)
        {
            _context = context;
        }
        public Result AutorJaCadastrado(string nomeAutor)
        {
            var autor = _context.Autores.FirstOrDefault(autor => autor.Nome == nomeAutor);

            if (autor != null)
            {
                return Result.Fail("Autor já cadastrado");
            }

            return Result.Ok();
        }
    }
}