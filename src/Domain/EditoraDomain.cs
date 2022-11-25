using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using cadastro_livros.Data;
using cadastro_livros.Interfaces;
using cadastro_livros.Models.Dtos.Editora;
using cadastro_livros.Models.Entities;

namespace cadastro_livros.Domain
{
    public class EditoraDomain : IEditora
    {
        public readonly AppDbContext _context;

        public readonly IMapper _mapper;

        public EditoraDomain(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadEditoraDto Adicionar(AddEditoraDto dto)
        {
            Editora editora = _mapper.Map<Editora>(dto);

            _context.Editoras.Add(editora);
            _context.SaveChanges();

            ReadEditoraDto editoraDto = _mapper.Map<ReadEditoraDto>(editora);

            return editoraDto;
        }

        public ReadEditoraDto BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReadEditoraDto> BuscarTodos()
        {

            var editoras = _context.Editoras.ToList();

            IEnumerable<ReadEditoraDto> editorasDto = _mapper.Map<List<ReadEditoraDto>>(editoras);

            return editorasDto;


        }

        public ReadEditoraDto Editar(int id, AddEditoraDto obj)
        {
            throw new NotImplementedException();
        }

        public bool Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}