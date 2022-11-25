using cadastro_livros.Interfaces;
using cadastro_livros.Models.Dtos.Livro;
using Microsoft.AspNetCore.Mvc;

namespace cadastro_livros.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivro _interfaces;

        public LivroController(ILivro interfaces)
        {
            _interfaces = interfaces;
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddLivroDto dto)
        {
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
    }
}