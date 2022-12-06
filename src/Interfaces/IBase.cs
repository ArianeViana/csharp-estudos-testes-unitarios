namespace cadastro_livros.Interfaces
{
    public interface IBase<in T, out A>
    {
        A Adicionar(T obj);
        IEnumerable<A> BuscarTodos();
        A BuscarPorId(int id);
        bool Excluir(int id);
        IEnumerable<A> BuscarPorNome(string nome);
    }
}