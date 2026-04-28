using iShopping.Models;
using System.Data.Entity;

namespace iShopping.Data
{
    public class iShoppingContext : DbContext
    {
        public iShoppingContext() : base("name=iShoppingDB")
        {
        }

        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<TipoArtigo> TiposArtigo { get; set; }
        public DbSet<Artigo> Artigos { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<ItemCompra> ItensCompra { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TipoArtigo>()
                .HasMany(t => t.Artigos)
                .WithRequired(a => a.TipoArtigo)
                .HasForeignKey(a => a.IdTipoArtigo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Compra>()
                .HasRequired(c => c.UtilizadorCriacao)
                .WithMany(u => u.ComprasCriadas)
                .HasForeignKey(c => c.IdUtilizadorCriacao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Compra>()
                .HasOptional(c => c.UtilizadorFechou)
                .WithMany(u => u.ComprasFechadas)
                .HasForeignKey(c => c.IdUtilizadorFechou)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Orcamento>()
                .HasRequired(o => o.UtilizadorCriacao)
                .WithMany(u => u.OrcamentosCriados)
                .HasForeignKey(o => o.IdUtilizadorCriacao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Orcamento>()
                .HasOptional(o => o.UtilizadorAlteracao)
                .WithMany(u => u.OrcamentosAlterados)
                .HasForeignKey(o => o.IdUtilizadorAlteracao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ItemCompra>()
                .HasRequired(i => i.Compra)
                .WithMany(c => c.ItensCompra)
                .HasForeignKey(i => i.IdCompra)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ItemCompra>()
                .HasRequired(i => i.Artigo)
                .WithMany(a => a.ItensCompra)
                .HasForeignKey(i => i.IdArtigo)
                .WillCascadeOnDelete(false);
        }
    }
}
