using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iShopping.Models
{
    public class ItemCompra
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A compra e obrigatoria.")]
        public int IdCompra { get; set; }

        [Required(ErrorMessage = "O artigo e obrigatorio.")]
        public int IdArtigo { get; set; }

        [Column(TypeName = "decimal")]
        public decimal QuantidadePrevista { get; set; }

        [Column(TypeName = "decimal")]
        public decimal? QuantidadeAdquirida { get; set; }

        [Column(TypeName = "decimal")]
        public decimal PrecoUnitario { get; set; }

        [StringLength(500, ErrorMessage = "As observacoes devem ter ate 500 caracteres.")]
        public string Observacoes { get; set; }

        public bool ArtigoPrevisto { get; set; }

        public virtual Compra Compra { get; set; }
        public virtual Artigo Artigo { get; set; }
    }
}
