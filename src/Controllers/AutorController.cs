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

            return NotFound("Autores não encontrados.");
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var autor = _interfaces.BuscarPorId(id);

            if (autor != null)
            {
                return Ok(autor);
            }

            return NotFound("Autor não encontrado.");
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, UpdateAutorDto dto)
        {

            var autor = _interfaces.Editar(id, dto);

            if (autor != null)
            {
                return Ok("Autor atualizado com sucesso.");
            }

            return BadRequest("Falha ao atualizar Autor.");

        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {

            var autorDeletado = _interfaces.Excluir(id);

            if (autorDeletado == true)
            {
                return Ok("Autor deletado com sucesso.");
            }

            return BadRequest("Falha ao deletar Autor.");

        }

    }
}