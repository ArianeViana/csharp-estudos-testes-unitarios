using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cadastro_livros.Controllers;
using cadastro_livros.Interfaces;
using cadastro_livros.Models.Dtos.Autor;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace testesApi.Controllers
{
    public class AutorControllerTest
    {

        private readonly Mock<IAutor> _IAutorMock = new();
        private readonly AutorController _controller;
        private readonly AddAutorDto _addAutorDto;
        private readonly ReadAutorDto _readAutorDto;
        private readonly List<ReadAutorDto> _listaAutores;

        public AutorControllerTest()
        {
            _addAutorDto = new AddAutorDto { Nome = "Neil Gaiman", Nacionalidade = "Inglaterra" };

            _readAutorDto = new ReadAutorDto { Id = 1, Nome = _addAutorDto.Nome, Nacionalidade = _addAutorDto.Nacionalidade };

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
        public void BuscarAutores_QuandoExisteAutores_Deve_RetornarAutores()
        {
            //Arrange
            _IAutorMock
            .Setup(domain => domain.BuscarTodos())
            .Returns(_listaAutores);

            int statusEsperado = 200;

            //Act
            var response = _controller.BuscarAutores();
            var responseObject = response as ObjectResult;

            //Assert
            Assert.NotNull(responseObject);
            Assert.Equal(statusEsperado, responseObject?.StatusCode);
            Assert.Equal(responseObject?.Value, _listaAutores);

        }
    }
}