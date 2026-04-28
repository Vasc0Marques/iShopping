using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iShopping.Models
{
    public class TipoArtigo
    {
        public TipoArtigo()
        {
            Artigos = new HashSet<Artigo>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "A descricao e obrigatoria.")]
        [StringLength(80, ErrorMessage = "A descricao deve ter ate 80 caracteres.")]
        public string Descricao { get; set; }

        public virtual ICollection<Artigo> Artigos { get; set; }
    }
}
