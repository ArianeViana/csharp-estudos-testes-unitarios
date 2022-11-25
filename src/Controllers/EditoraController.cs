using cadastro_livros.Exceptions.Interfaces;
using cadastro_livros.Interfaces;
using cadastro_livros.Models.Dtos.Editora;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace cadastro_livros.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EditoraController : ControllerBase
    {
        private readonly IEditora _interfaces;

        private readonly IEditoraException _exceptions;

        public EditoraController(IEditora interfaces, IEditoraException exceptions)
        {
            _interfaces = interfaces;
            _exceptions = exceptions;
        }

        public static IEnumerable<String> messageException(Result resultado)
        {
            return resultado.Reasons.Select(reason => reason.Message);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddEditoraDto dto)
        {
            Result editoraJaCadastrada = _exceptions.EditoraJaCadastrada(dto.Nome);

            if (editoraJaCadastrada.IsFailed)
            {
                return BadRequest(messageException(editoraJaCadastrada));
            }

            var editora = _interfaces.Adicionar(dto);

            if (editora != null)
            {
                return Ok("Editora salva com sucesso!");
            }

            return BadRequest("Falha ao salvar Editora.");

        }

        [HttpGet]
        public IActionResult Get()
        {
            var editoras = _interfaces.BuscarTodos();

            if (editoras != null)
            {
                return Ok(editoras);
            }

            return NotFound("Editoras não encontradas");
        }
    }
}