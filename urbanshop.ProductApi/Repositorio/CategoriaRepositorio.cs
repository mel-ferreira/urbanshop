using Microsoft.EntityFrameworkCore;
using urbanshop.ProductApi.Context;
using urbanshop.ProductApi.Models;

namespace urbanshop.ProductApi.Repositorio;

public class CategoriaRepositorio : ICategoriaRepositorio
{
    private readonly AppDbContext _appDbContext;

    public CategoriaRepositorio(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<Categoria>> GetAll()
    {
        return await _appDbContext.Categorias.ToListAsync();
    }
    public async Task<Categoria?> GetById(int id)
    {
        return await _appDbContext.Categorias
            .Where(c => c.CategoriaId == id)
            .FirstOrDefaultAsync();
    }
    public async Task<IEnumerable<Categoria>> GetCategoriaProdutos()
    {
        return await _appDbContext.Categorias.Include(p => p.Produtos).ToListAsync();
    }
    public async Task<Categoria> Create(Categoria categoria)
    {
        _appDbContext.Categorias.Add(categoria);
        await _appDbContext.SaveChangesAsync();

        return categoria;
    }
    public async Task<Categoria> Update(Categoria categoria)
    {
        _appDbContext.Entry(categoria).State = EntityState.Modified;
        await _appDbContext.SaveChangesAsync();

        return categoria;

    }
    public async Task<Categoria> Delete(int id)
    {
        var categoria = await GetById(id);
        _appDbContext.Categorias.Remove(categoria);
        await _appDbContext.SaveChangesAsync();

        return categoria;
    }
}
