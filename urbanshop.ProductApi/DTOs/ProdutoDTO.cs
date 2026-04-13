using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using urbanshop.ProductApi.Models;


namespace urbanshop.ProductApi.DTOs;

public class ProdutoDTO
{
    public int ProdutoId { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O preço é obrigatório.")]
    public decimal Preco { get; set; }
    
    [Required(ErrorMessage = "A descrição é obrigatório.")]
    [MinLength(5)]
    [MaxLength(200)]
    public string? Descricao { get; set; }
    
    [Required(ErrorMessage = "O número de estoque é obrigatório")]
    [Range(1,999)]
    public long  Estoque { get; set; }
    public string? ImagemURL{ get; set; }
    [JsonIgnore]
    public Categoria? Categoria { get; set; }
    public int CategoriaId { get; set; }
}