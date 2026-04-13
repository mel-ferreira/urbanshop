using Microsoft.AspNetCore.Mvc;
using urbanshop.ProductApi.DTOs;
using urbanshop.ProductApi.Services;

namespace urbanshop.ProductApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutosController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
    {
        var produtosDto = _produtoService.GetProdutos();
        if (produtosDto is null)
        {
            return NotFound("Não há produto registrado ou não foi encontrado.");
        }
        return Ok(produtosDto);
    }
    [HttpGet("{id:int}", Name = "GetProdutos")]
    public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetById(int id)
    {
        var produtosDto = _produtoService.GetProdutoById(id);
        if (produtosDto is null)
        {
            return NotFound("Não há produtos registrados ou encontrados.");
        }
        return Ok(produtosDto);
    }
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProdutoDTO produtosDto)
    {
        if (produtosDto is null)
        {
            return BadRequest("Dados inválidos.");
        }
        await _produtoService.AddProduto(produtosDto);

        return new CreatedAtRouteResult("GetProduto", new { id = produtosDto.ProdutoId });
    }
    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] ProdutoDTO produtosDto)
    {
        if (id != produtosDto.ProdutoId)
        {
            return BadRequest();
        }
        if (produtosDto is null)
        {
            return NotFound();
        }
        await _produtoService.UpdateProduto(produtosDto);
        return Ok(produtosDto);
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<CategoriaDTO>> Delete(int id)
    {

        var produtosDto = await _produtoService.GetProdutoById(id);

        if (id != produtosDto.ProdutoId)
        {
            return NotFound("Produto não encontrado");
        }
        await _produtoService.RemoveProduto(id);

        return Ok(id);

    }

}
