using urbanshop.ProductApi.Models;

namespace urbanshop.ProductApi.Repositorio;
public interface IProdutoRepositorio
{
    Task<IEnumerable<Produto>> GetAll();
    Task<Produto> GetById(int id);
    Task<Produto> Create(Produto produto);
    Task<Produto> Update(Produto produto);
    Task<Produto> Delete(int id);
}
