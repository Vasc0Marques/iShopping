using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iShopping.Models
{
    public class Compra
    {
        public Compra()
        {
            ItensCompra = new HashSet<ItemCompra>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "O nome e obrigatorio.")]
        [StringLength(120, ErrorMessage = "O nome deve ter ate 120 caracteres.")]
        public string Nome { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public DateTime? DataFechada { get; set; }

        [Required(ErrorMessage = "O utilizador de criacao e obrigatorio.")]
        public int IdUtilizadorCriacao { get; set; }

        public int? IdUtilizadorFechou { get; set; }

        public virtual Utilizador UtilizadorCriacao { get; set; }
        public virtual Utilizador UtilizadorFechou { get; set; }

        public virtual ICollection<ItemCompra> ItensCompra { get; set; }
    }
}
