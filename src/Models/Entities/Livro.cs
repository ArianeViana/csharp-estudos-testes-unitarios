
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace cadastro_livros.Models.Entities
{
    [Table("livros")]
    public class Livro
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("titulo")]
        public string Titulo { get; set; }

        [JsonIgnore]
        public virtual Autor Autor { get; set; }

        [JsonIgnore]
        public int AutorId { get; set; }

        [Required]
        [Column("isbn-13")]
        public string Isbn13 { get; set; }

        [Required]
        [Column("isbn-10")]
        public string Isbn10 { get; set; }


        [Required]
        [Column("numero_paginas")]
        public int NumeroPaginas { get; set; }

        [Required]
        [Column("ano_lancamento")]
        public string AnoLancamento { get; set; }

        [Required]
        [Column("idioma")]
        public string Idioma { get; set; }

        [JsonIgnore]
        public virtual Editora Editora { get; set; }

        [JsonIgnore]
        public int EditoraId { get; set; }




    }
}