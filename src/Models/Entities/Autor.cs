using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace cadastro_livros.Models.Entities
{
    [Table("autores")]
    public class Autor
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("nome")]
        public string Nome { get; set; }

        [Required]
        [Column("nacionalidade")]
        public string Nacionalidade { get; set; }

        [JsonIgnore]
        public virtual List<Livro> Livros { get; set; }

    }
}