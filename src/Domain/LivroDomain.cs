
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
            var livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);

            ReadLivroDto livroDto = _mapper.Map<ReadLivroDto>(livro);

            return livroDto;
        }

        public IEnumerable<ReadLivroDto> BuscarTodos()
        {
            var livros = _context.Livros.ToList();

            IEnumerable<ReadLivroDto> livrosDto = _mapper.Map<List<ReadLivroDto>>(livros);

            return livrosDto;
        }

        public IEnumerable<ReadLivroDto> BuscarPorTituloLivro(string tituloLivro)
        {
            var livros = _context.Livros.Where(livro => livro.Titulo.Contains(tituloLivro)).ToList();

            IEnumerable<ReadLivroDto> livrosDto = _mapper.Map<List<ReadLivroDto>>(livros);

            return livrosDto;
        }

        public ReadLivroDto Editar(int id, UpdateLivroDto dto)
        {
            var livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);

            if (livro != null)
            {
                _mapper.Map(dto, livro);
                _context.SaveChanges();

                ReadLivroDto livroDto = _mapper.Map<ReadLivroDto>(livro);

                return livroDto;
            }

            return null;

        }

        public bool Excluir(int id)
        {
            var livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);

            if (livro != null)
            {
                _context.Livros.Remove(livro);
                _context.SaveChanges();

                return true;
            }

            return false;

        }
    }
}