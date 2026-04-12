using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using urbanshop.ProductApi.Models;


namespace urbanshop.ProductApi.DTOs;

public class CategoriaDTO
{
    public int CategoriaId { get; set; }

    [Required(ErrorMessage = "O nome da categoria é obrigatória.")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Nome { get; set; }

    public ICollection<Produto> Produtos  {get; set; }
}
