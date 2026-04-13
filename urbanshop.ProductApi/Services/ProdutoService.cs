using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using urbanshop.ProductApi.DTOs;
using urbanshop.ProductApi.Models;
using urbanshop.ProductApi.Repositorio;

namespace urbanshop.ProductApi.Services
{
    public class ProdutoService : IProdutoService
    {

        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepositorio produtoRepositorio, IMapper mapper)
        {
            _produtoRepositorio = produtoRepositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
        {
            var produtosEntidade = await _produtoRepositorio.GetAll();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtosEntidade);
        }
        public async Task<ProdutoDTO> GetProdutoById(int id)
        {
            var produtosEntidade = await _produtoRepositorio.GetById(id);
            return _mapper.Map<ProdutoDTO>(produtosEntidade);
        }
        public async Task AddProduto(ProdutoDTO produtoDto)
        {
            var produtosEntidade = _mapper.Map<Produto>(produtoDto);
            await _produtoRepositorio.Create(produtosEntidade);
            produtoDto.ProdutoId = produtosEntidade.ProdutoId;
        }
        public async Task UpdateProduto(ProdutoDTO produtoDto)
        {
            var produtosEntidade = _mapper.Map<Produto>(produtoDto);
            await _produtoRepositorio.Update(produtosEntidade);
        }
        public async Task RemoveProduto(int id)
        {
            var produtosEntidade = _produtoRepositorio.GetById(id).Result;
            await _produtoRepositorio.Delete(produtosEntidade.ProdutoId);
        }
    }
}
