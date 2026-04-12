using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using urbanshop.ProductApi.Models;

namespace urbanshop.ProductApi.Repositorio;

public interface ICategoriaRepositorio
{
    Task<IEnumerable<Categoria>>GetAll();
    Task<Categoria> GetById(int id);

    Task<IEnumerable<Categoria>> GetCategoriaProdutos();
    Task<Categoria>Create(Categoria categoria);
    Task<Categoria>Update(Categoria categoria);
    Task<Categoria>Delete(int id);

}