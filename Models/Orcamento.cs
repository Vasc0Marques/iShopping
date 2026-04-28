using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iShopping.Models
{
    public class Orcamento
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Valor { get; set; }

        [Range(1, 12, ErrorMessage = "O mes deve estar entre 1 e 12.")]
        public int Mes { get; set; }

        [Range(2000, 2100, ErrorMessage = "O ano deve estar entre 2000 e 2100.")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "O utilizador de criacao e obrigatorio.")]
        public int IdUtilizadorCriacao { get; set; }

        public int? IdUtilizadorAlteracao { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public DateTime? DataAlteracao { get; set; }

        public virtual Utilizador UtilizadorCriacao { get; set; }
        public virtual Utilizador UtilizadorAlteracao { get; set; }
    }
}
