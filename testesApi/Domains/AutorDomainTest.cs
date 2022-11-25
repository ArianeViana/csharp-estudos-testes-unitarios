using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using cadastro_livros.Domain;
using cadastro_livros.Models.Dtos.Autor;
using cadastro_livros.Models.Entities;
using Moq;

namespace testesApi.Domains
{
    public class AutorDomainTest
    {
        /*Nomenclatura e organização dos métodos
        - O nome do seu teste deve ser composto por três partes:
        - O nome do método que está sendo testado.
        - O cenário em que ele está sendo testado.
        - O comportamento esperado quando o cenário é invocado.*/

        private readonly DbContextInMemory _DbContext;
        private readonly Mock<IMapper> _mapperMock;
        private readonly AutorDomain _domain;
        private readonly AddAutorDto _addAutorDto;
        private readonly ReadAutorDto _readAutorDto;
        private readonly Autor _autorModel;
        private readonly List<ReadAutorDto> _listaAutores;


        public AutorDomainTest()
        {
            _DbContext = new DbContextInMemory();

            _mapperMock = new Mock<IMapper>();

            _domain = new AutorDomain(_DbContext, _mapperMock.Object);

            _addAutorDto = new AddAutorDto { Nome = "Neil Gaiman", Nacionalidade = "Inglaterra" };

            _readAutorDto = new ReadAutorDto { Id = 1, Nome = _addAutorDto.Nome, Nacionalidade = _addAutorDto.Nacionalidade };

            _autorModel = new Autor { Id = _readAutorDto.Id, Nome = _readAutorDto.Nome, Nacionalidade = _readAutorDto.Nacionalidade };

            _listaAutores = new List<ReadAutorDto>()
            {
                new ReadAutorDto{
                    Id = 1,
                    Nome = "Machado de Assis",
                    Nacionalidade = "Brasil"
                },

                new ReadAutorDto{
                    Id = 2,
                    Nome = "Elena Ferrante",
                    Nacionalidade = "Itália"
                }
            };
        }

        [Fact]
        public void Adicionar_AutorNaoCadastrado_Deve_RetornarConteudoSalvo()
        {

            //Arrange 
            _mapperMock
            .Setup(mapper => mapper.Map<Autor>(It.IsAny<AddAutorDto>()))
            .Returns(_autorModel);

            _mapperMock
            .Setup(mapper => mapper.Map<ReadAutorDto>(It.IsAny<Autor>()))
            .Returns(_readAutorDto);

            //Act
            var adicionarAutor = _domain.Adicionar(_addAutorDto);

            var autorSalvo = _DbContext.Autores.FirstOrDefault(autor => autor.Id == _autorModel.Id);

            //Assert
            Assert.NotNull(autorSalvo);
            Assert.IsType<ReadAutorDto>(adicionarAutor);
            Assert.Equal(autorSalvo, _autorModel);
        }

        [Fact]
        public void BuscarTodos_Deve_RetornarListaDeConteudos()
        {
            //Arrange
            _mapperMock
            .Setup(mapper => mapper.Map<List<ReadAutorDto>>(_DbContext.Autores.ToList()))
            .Returns(_listaAutores);

            //Act
            IEnumerable<ReadAutorDto> todosAutores = _domain.BuscarTodos();

            //Assert
            Assert.NotNull(todosAutores);
            Assert.IsType<List<ReadAutorDto>>(todosAutores);
            Assert.Equal(2, todosAutores.Count());
            Assert.Equal(_listaAutores, todosAutores);

        }

        [Fact]
        public void BuscarPorId_ComIdValido_Deve_RetornarUmAgendamento()
        {

            //Arrange
            Autor autor = new Autor { Id = 2, Nome = "Jane Austen", Nacionalidade = "Inglaterra" };
            ReadAutorDto dto = new ReadAutorDto { Id = autor.Id, Nome = autor.Nome, Nacionalidade = autor.Nacionalidade };

            _DbContext.Autores.Add(autor);
            _DbContext.SaveChanges();

            _mapperMock
            .Setup(mapper => mapper.Map<ReadAutorDto>(It.IsAny<Autor>()))
            .Returns(dto);

            //Act
            var autorRetornado = _domain.BuscarPorId(autor.Id);

            //Assert
            Assert.NotNull(autorRetornado);
            Assert.Equal(dto, autorRetornado);
            Assert.Equal(autor.Id, autorRetornado.Id);

        }

        [Fact]
        public void Excluir_ComIdValido_Deve_RetornarTrue()
        {
            //Arrange
            Autor autor = new Autor { Id = 3, Nome = "Rick Riordan", Nacionalidade = "EUA" };
            ReadAutorDto dto = new ReadAutorDto { Id = autor.Id, Nome = autor.Nome, Nacionalidade = autor.Nacionalidade };

            _DbContext.Autores.Add(autor);
            _DbContext.SaveChanges();

            //Act
            var autorDeletado = _domain.Excluir(autor.Id);

            //Assert
            Assert.Equal(true, autorDeletado);
        }

        [Fact]
        public void Excluir_ComIdInvalido_Deve_RetornarTrue()
        {
            //Arrange
            Autor autor = new Autor { Id = 3, Nome = "Rick Riordan", Nacionalidade = "EUA" };
            ReadAutorDto dto = new ReadAutorDto { Id = autor.Id, Nome = autor.Nome, Nacionalidade = autor.Nacionalidade };

            _DbContext.Autores.Add(autor);
            _DbContext.SaveChanges();

            //Act
            var autorDeletado = _domain.Excluir(5);

            //Assert
            Assert.Equal(false, autorDeletado);
        }

    }
}