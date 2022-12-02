using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cadastro_livros.Data;
using cadastro_livros.Exceptions.Interfaces;
using FluentResults;

namespace cadastro_livros.Exceptions
{
    public class LivroException : ILivroException
    {
        public readonly AppDbContext _context;

        public LivroException(AppDbContext context)
        {
            _context = context;
        }
        public Result LivroJaCadastrado(string isbn13)
        {
            var livro = _context.Livros.FirstOrDefault(livro => livro.Isbn13 == isbn13);

            if (livro != null)
            {
                return Result.Fail("Livro já cadastrado.");
            }

            return Result.Ok();
        }
    }
}