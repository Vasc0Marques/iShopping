using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iShopping.Models
{
    public class Artigo
    {
        public Artigo()
        {
            ItensCompra = new HashSet<ItemCompra>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "A descricao e obrigatoria.")]
        [StringLength(120, ErrorMessage = "A descricao deve ter ate 120 caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O tipo de artigo e obrigatorio.")]
        public int IdTipoArtigo { get; set; }

        [Column(TypeName = "decimal")]
        public decimal PrecoMedio { get; set; }

        public virtual TipoArtigo TipoArtigo { get; set; }
        public virtual ICollection<ItemCompra> ItensCompra { get; set; }
    }
}
