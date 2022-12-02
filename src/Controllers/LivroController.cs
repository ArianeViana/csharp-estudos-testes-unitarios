using cadastro_livros.Exceptions.Interfaces;
using cadastro_livros.Interfaces;
using cadastro_livros.Models.Dtos.Livro;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace cadastro_livros.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivro _interfaces;

        private readonly ILivroException _exceptions;

        public LivroController(ILivro interfaces, ILivroException exceptions)
        {
            _interfaces = interfaces;
            _exceptions = exceptions;
        }

        public static IEnumerable<String> messageException(Result resultado)
        {
            return resultado.Reasons.Select(reason => reason.Message);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddLivroDto dto)
        {
            Result livroJaCadastrado = _exceptions.LivroJaCadastrado(dto.Isbn13);

            if (livroJaCadastrado.IsFailed)
            {
                return BadRequest(messageException(livroJaCadastrado));
            }

            var livro = _interfaces.Adicionar(dto);

            if (livro != null)
            {
                return Ok("Livro salvo com sucesso!");
            }

            return BadRequest("Falha ao salvar Livro.");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var livros = _interfaces.BuscarTodos();

            if (livros != null)
            {
                return Ok(livros);
            }

            return NotFound("Livros não encontrados");
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var livro = _interfaces.BuscarPorId(id);

            if (livro != null)
            {
                return Ok(livro);
            }

            return NotFound("Livro não encontrado.");
        }

        [HttpGet("buscarPorTitulo/{tituloLivro}")]
        public IActionResult BuscarPorTitulo(string tituloLivro)
        {
            var livros = _interfaces.BuscarPorTituloLivro(tituloLivro);

            if (livros != null)
            {
                return Ok(livros);
            }

            return NotFound("Livro não encontrado.");
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, UpdateLivroDto dto)
        {

            var livro = _interfaces.Editar(id, dto);

            if (livro != null)
            {
                return Ok("Livro atualizado com sucesso.");
            }

            return BadRequest("Falha ao atualizar Livro.");

        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {

            var livro = _interfaces.Excluir(id);

            if (livro == true)
            {
                return Ok("Livro deletado com sucesso.");
            }

            return BadRequest("Falha ao deletar Livro.");

        }
    }
}