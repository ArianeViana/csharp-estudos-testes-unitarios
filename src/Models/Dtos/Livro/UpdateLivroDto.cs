using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastro_livros.Models.Dtos.Livro
{
    public class UpdateLivroDto
    {
        public string Titulo { get; set; }

        public int AutorId { get; set; }

        public string Isbn13 { get; set; }

        public string Isbn10 { get; set; }

        public int NumeroPaginas { get; set; }

        public string AnoLancamento { get; set; }

        public string Idioma { get; set; }

        public int EditoraId { get; set; }
    }
}