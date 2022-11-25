namespace cadastro_livros.Interfaces
{
    public interface IBase<in T, out A>
    {
        A Adicionar(T obj);
        IEnumerable<A> BuscarTodos();
        A BuscarPorId(int id);
        A Editar(int id, T obj);
        bool Excluir(int id);


    }
}