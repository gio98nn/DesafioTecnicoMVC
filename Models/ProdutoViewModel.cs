using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace produtoMVC.Models
{
    public class ProdutoViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Titulo { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
    }
}