using cadastro_livros.Exceptions.Interfaces;
using cadastro_livros.Interfaces;
using cadastro_livros.Models.Dtos.Autor;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace cadastro_livros.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IAutor _interfaces;

        private readonly IAutorException _exceptions;

        public AutorController(IAutor interfaces, IAutorException exceptions)
        {
            _interfaces = interfaces;
            _exceptions = exceptions;
        }

        public static IEnumerable<String> messageException(Result resultado)
        {
            return resultado.Reasons.Select(reason => reason.Message);
        }

        [HttpPost]
        public IActionResult SalvarAutores([FromBody] AddAutorDto dto)
        {
            Result autorJaCadastrado = _exceptions.AutorJaCadastrado(dto.Nome);

            if (autorJaCadastrado.IsFailed)
            {
                return BadRequest(messageException(autorJaCadastrado));
            }

            var autor = _interfaces.Adicionar(dto);

            if (autor != null)
            {
                return Ok("Autor salvo com sucesso!");
            }

            return BadRequest("Falha ao salvar Autor.");
        }

        [HttpGet]
        public IActionResult BuscarAutores()
        {
            var autores = _interfaces.BuscarTodos();

            if (autores != null)
            {
                return Ok(autores);
            }

            return NotFound("Autores não encontrados");
        }

    }
}