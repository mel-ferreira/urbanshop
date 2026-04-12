using Microsoft.EntityFrameworkCore;
using urbanshop.ProductApi.Context;
using urbanshop.ProductApi.Models;

namespace urbanshop.ProductApi.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly AppDbContext _appDbContext;

        public ProdutoRepositorio(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _appDbContext.Produtos.ToListAsync();
        }
        public async Task<Produto?> GetById(int id)
        {
            return await _appDbContext.Produtos.Where(p => p.ProdutoId == id)
                .FirstOrDefaultAsync();
        }
        public async Task<Produto> Create(Produto produto)
        {
            _appDbContext.Produtos.Add(produto);
            await _appDbContext.SaveChangesAsync();

            return produto;
        }
        public async Task<Produto> Update(Produto produto)
        {
            _appDbContext.Entry(produto).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();

            return produto;

        }
        public async Task<Produto> Delete(int id)
        {
            var produto = await GetById(id);
            _appDbContext.Produtos.Remove(produto);
            await _appDbContext.SaveChangesAsync();

            return produto;
        }
    }
}
