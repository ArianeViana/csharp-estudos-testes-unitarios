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

            return NotFound("Editoras não encontradas.");
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var editora = _interfaces.BuscarPorId(id);

            if (editora != null)
            {
                return Ok(editora);
            }

            return NotFound("Editora não encontrada.");
        }

        [HttpGet("buscarPorNome/{nomeEditora}")]
        public IActionResult BuscarPorNome(string nomeEditora)
        {
            var editoras = _interfaces.BuscarPorNome(nomeEditora);

            if (editoras != null)
            {
                return Ok(editoras);
            }

            return NotFound("Editora não encontrada.");
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, UpdateEditoraDto dto)
        {

            var editora = _interfaces.Editar(id, dto);

            if (editora != null)
            {
                return Ok("Editora atualizada com sucesso.");
            }

            return BadRequest("Falha ao atualizar Editora.");

        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {

            var editora = _interfaces.Excluir(id);

            if (editora == true)
            {
                return Ok("Editora deletada com sucesso.");
            }

            return BadRequest("Falha ao deletar Editora.");

        }
    }
}