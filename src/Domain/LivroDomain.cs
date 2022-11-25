
using AutoMapper;
using cadastro_livros.Data;
using cadastro_livros.Interfaces;
using cadastro_livros.Models.Dtos;
using cadastro_livros.Models.Dtos.Livro;
using cadastro_livros.Models.Entities;

namespace cadastro_livros.Domain
{
    public class LivroDomain : ILivro
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public LivroDomain(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadLivroDto Adicionar(AddLivroDto dto)
        {
            Livro livro = _mapper.Map<Livro>(dto);

            _context.Livros.Add(livro);
            _context.SaveChanges();

            ReadLivroDto livroDto = _mapper.Map<ReadLivroDto>(livro);

            return livroDto;
        }

        public ReadLivroDto BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReadLivroDto> BuscarTodos()
        {
            var livros = _context.Livros.ToList();

            IEnumerable<ReadLivroDto> livrosDto = _mapper.Map<List<ReadLivroDto>>(livros);

            return livrosDto;
        }

        public ReadLivroDto Editar(int id, AddLivroDto obj)
        {
            throw new NotImplementedException();
        }

        public bool Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}