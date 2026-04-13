using Microsoft.AspNetCore.Mvc;
using urbanshop.ProductApi.DTOs;
using urbanshop.ProductApi.Services;

namespace urbanshop.ProductApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;

    public CategoriasController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
    {
        var categoriasDto = await _categoriaService.GetCategorias();
        if (categoriasDto is null)
        {
            return NotFound("Não há categorias registradas ou não foram encontradas.");
        }
        return Ok(categoriasDto);
    }
    [HttpGet("produtos")]
    public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategoriaProdutos()
    {
        var categoriasDto = await _categoriaService.GetCategoriaProdutos();
        if (categoriasDto is null)
        {
            return NotFound("Não há categorias vínculas à produtos ou não foram encontradas.");
        }
        return Ok(categoriasDto);
    }
    [HttpGet("{id:int}", Name = "GetCategoria")]
    public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetById(int id)
    {
        var categoriasDto = await _categoriaService.GetCategoriaById(id);
        if (categoriasDto is null)
        {
            return NotFound("Não há categoria registrada ou encontrada.");
        }
        return Ok(categoriasDto);
    }
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDTO)
    {
        if (categoriaDTO is null)
        {
            return BadRequest("Dados inválidos.");
        }
        await _categoriaService.AddCategoria(categoriaDTO);

        return new CreatedAtRouteResult("GetCategoria", new { id = categoriaDTO.CategoriaId });
    }
    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] CategoriaDTO categoriaDTO)
    {
        if( id != categoriaDTO.CategoriaId)
        {
            return BadRequest();
        }
        if (categoriaDTO is null)
        {
            return NotFound();
        }
        await _categoriaService.UpdateCategoria(categoriaDTO);
        return Ok(categoriaDTO);
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<CategoriaDTO>>Delete(int id)
    {

        var categoriaDTO = await _categoriaService.GetCategoriaById(id);

        if (id != categoriaDTO.CategoriaId)
        {
            return NotFound("Categoria não encontrada.");
        }
        await _categoriaService.RemoveCategoria(id);

        return Ok(id);

    }
}
