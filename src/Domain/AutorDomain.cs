using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using cadastro_livros.Data;
using cadastro_livros.Interfaces;
using cadastro_livros.Models.Dtos.Autor;
using cadastro_livros.Models.Entities;
using FluentResults;

namespace cadastro_livros.Domain
{
    public class AutorDomain : IAutor
    {
        public readonly AppDbContext _context;

        public readonly IMapper _mapper;

        public AutorDomain(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadAutorDto Adicionar(AddAutorDto dto)
        {
            Autor autor = _mapper.Map<Autor>(dto);

            _context.Autores.Add(autor);
            _context.SaveChanges();

            ReadAutorDto autorDto = _mapper.Map<ReadAutorDto>(autor);

            return autorDto;
        }

        public ReadAutorDto BuscarPorId(int id)
        {
            var autorBuscado = _context.Autores.FirstOrDefault(autor => autor.Id == id);

            ReadAutorDto autorDto = _mapper.Map<ReadAutorDto>(autorBuscado);

            return autorDto;
        }

        public IEnumerable<ReadAutorDto> BuscarTodos()
        {

            var autores = _context.Autores.ToList();

            IEnumerable<ReadAutorDto> autoresDto = _mapper.Map<List<ReadAutorDto>>(autores);

            return autoresDto;


        }

        public ReadAutorDto Editar(int id, AddAutorDto dto)
        {
            var autorBuscado = _context.Autores.FirstOrDefault(autor => autor.Id == id);

            if (autorBuscado != null)
            {
                _mapper.Map(dto, autorBuscado);

                ReadAutorDto autorDto = _mapper.Map<ReadAutorDto>(autorBuscado);

                _context.SaveChanges();

                return autorDto;
            }

            return null;
        }

        public bool Excluir(int id)
        {
            var autorBuscado = _context.Autores.FirstOrDefault(autor => autor.Id == id);

            if (autorBuscado != null)
            {

                _context.Autores.Remove(autorBuscado);
                _context.SaveChanges();
                return true;
            }

            return false;

        }
    }
}