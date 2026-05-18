using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using iShopping.Data;

namespace iShopping.Models
{
    public class Utilizador
    {
        public Utilizador()
        {
            ComprasCriadas = new HashSet<Compra>();
            ComprasFechadas = new HashSet<Compra>();
            OrcamentosCriados = new HashSet<Orcamento>();
            OrcamentosAlterados = new HashSet<Orcamento>();
        }


        public int Id { get; set; }

        [Required (ErrorMessage = "O nome é obrigatório.")]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required (ErrorMessage = "O nome de utilizador é obrigatório.")]
        [StringLength(20)]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [Required (ErrorMessage = "A palavra-passe é obrigatória.")]
        [StringLength(100)]
        public string Password { get; set; }

        public DateTime DataRegisto { get; set; } = DateTime.Now;

        public virtual ICollection<Compra> ComprasCriadas { get; set; }
        public virtual ICollection<Compra> ComprasFechadas { get; set; }
        public virtual ICollection<Orcamento> OrcamentosCriados { get; set; }
        public virtual ICollection<Orcamento> OrcamentosAlterados { get; set; }
    }
}
