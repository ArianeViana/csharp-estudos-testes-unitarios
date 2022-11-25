using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace cadastrolivros.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "autores",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    nacionalidade = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "editoras",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_editoras", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "livros",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    titulo = table.Column<string>(type: "text", nullable: false),
                    autorid = table.Column<int>(name: "autor_id", type: "integer", nullable: false),
                    isbn13 = table.Column<string>(name: "isbn-13", type: "text", nullable: false),
                    isbn10 = table.Column<string>(name: "isbn-10", type: "text", nullable: false),
                    numeropaginas = table.Column<int>(name: "numero_paginas", type: "integer", nullable: false),
                    anolancamento = table.Column<string>(name: "ano_lancamento", type: "text", nullable: false),
                    idioma = table.Column<string>(type: "text", nullable: false),
                    editoraid = table.Column<int>(name: "editora_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livros", x => x.id);
                    table.ForeignKey(
                        name: "FK_livros_autores_autor_id",
                        column: x => x.autorid,
                        principalTable: "autores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_livros_editoras_editora_id",
                        column: x => x.editoraid,
                        principalTable: "editoras",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_livros_autor_id",
                table: "livros",
                column: "autor_id");

            migrationBuilder.CreateIndex(
                name: "IX_livros_editora_id",
                table: "livros",
                column: "editora_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "livros");

            migrationBuilder.DropTable(
                name: "autores");

            migrationBuilder.DropTable(
                name: "editoras");
        }
    }
}
