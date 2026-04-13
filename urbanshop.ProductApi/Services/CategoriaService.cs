using AutoMapper;
using urbanshop.ProductApi.DTOs;
using urbanshop.ProductApi.Models;
using urbanshop.ProductApi.Repositorio;

namespace urbanshop.ProductApi.Services;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepositorio _categoriaRepositorio;
    private readonly IMapper _mapper;

    public CategoriaService(ICategoriaRepositorio categoriaRepositorio, IMapper mapper)
    {
        this._categoriaRepositorio = categoriaRepositorio;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
    {
        var categoriasEntidade = await _categoriaRepositorio.GetAll();
        return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriasEntidade);
    }
    public async Task<CategoriaDTO> GetCategoriaById(int id)
    {
        var categoriasEntidade = await _categoriaRepositorio.GetById(id);
        return _mapper.Map<CategoriaDTO>(categoriasEntidade);
    }
    public async Task<IEnumerable<CategoriaDTO>> GetCategoriaProdutos()
    {
        var categoriasEntidade = await _categoriaRepositorio.GetCategoriaProdutos();
        return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriasEntidade);
    }
    public async Task AddCategoria(CategoriaDTO categoriaDto)
    {
        var categoriaEntidade = _mapper.Map<Categoria>(categoriaDto);
        await _categoriaRepositorio.Create(categoriaEntidade);
        categoriaDto.CategoriaId = categoriaEntidade.CategoriaId;
    }
    public async Task UpdateCategoria(CategoriaDTO categoriaDto)
    {
        var categoriaEntidade = _mapper.Map<Categoria>(categoriaDto);
        await _categoriaRepositorio.Update(categoriaEntidade);
    }
    public async Task RemoveCategoria(int id)
    {
        var categoriaEntidade = _categoriaRepositorio.GetById(id).Result;
        await _categoriaRepositorio.Delete(categoriaEntidade.CategoriaId);
    }
}
