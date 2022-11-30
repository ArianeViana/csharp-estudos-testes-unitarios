using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastro_livros.Models.Dtos.Autor
{
    public class UpdateAutorDto
    {
        public string Nome { get; set; }
        public string Nacionalidade { get; set; }
    }
}