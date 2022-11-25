namespace cadastro_livros.Models.Dtos.Autor
{
    public class ReadAutorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Nacionalidade { get; set; }
        public virtual List<Models.Entities.Livro> Livros { get; set; }
    }
}