using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastro_livros.Models.Dtos.Editora
{
    public class ReadEditoraDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public virtual List<Models.Entities.Livro> Livros { get; set; }
    }
}