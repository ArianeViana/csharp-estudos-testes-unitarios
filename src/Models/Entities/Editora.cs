using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace cadastro_livros.Models.Entities
{
    [Table("editoras")]
    public class Editora
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("nome")]
        public string Nome { get; set; }

        [JsonIgnore]
        public virtual List<Livro> Livros { get; set; }

        //fazer depois relacionamento com autores - muitos para muitos
    }
}