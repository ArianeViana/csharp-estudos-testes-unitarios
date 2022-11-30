using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastro_livros.Interfaces
{
    public interface IUpdate<in T, out A>
    {
        A Editar(int id, T obj);
    }
}