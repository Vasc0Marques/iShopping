namespace iShopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artigoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 120),
                        IdTipoArtigo = c.Int(nullable: false),
                        PrecoMedio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoArtigoes", t => t.IdTipoArtigo)
                .Index(t => t.IdTipoArtigo);
            
            CreateTable(
                "dbo.ItemCompras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCompra = c.Int(nullable: false),
                        IdArtigo = c.Int(nullable: false),
                        QuantidadePrevista = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantidadeAdquirida = c.Decimal(precision: 18, scale: 2),
                        PrecoUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Observacoes = c.String(maxLength: 500),
                        ArtigoPrevisto = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artigoes", t => t.IdArtigo)
                .ForeignKey("dbo.Compras", t => t.IdCompra, cascadeDelete: true)
                .Index(t => t.IdCompra)
                .Index(t => t.IdArtigo);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 120),
                        DataCriacao = c.DateTime(nullable: false),
                        DataFechada = c.DateTime(),
                        IdUtilizadorCriacao = c.Int(nullable: false),
                        IdUtilizadorFechou = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilizadors", t => t.IdUtilizadorCriacao)
                .ForeignKey("dbo.Utilizadors", t => t.IdUtilizadorFechou)
                .Index(t => t.IdUtilizadorCriacao)
                .Index(t => t.IdUtilizadorFechou);
            
            CreateTable(
                "dbo.Utilizadors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 100),
                        DataRegisto = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true);
            
            CreateTable(
                "dbo.Orcamentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mes = c.Int(nullable: false),
                        Ano = c.Int(nullable: false),
                        IdUtilizadorCriacao = c.Int(nullable: false),
                        IdUtilizadorAlteracao = c.Int(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilizadors", t => t.IdUtilizadorAlteracao)
                .ForeignKey("dbo.Utilizadors", t => t.IdUtilizadorCriacao)
                .Index(t => t.IdUtilizadorCriacao)
                .Index(t => t.IdUtilizadorAlteracao);
            
            CreateTable(
                "dbo.TipoArtigoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Artigoes", "IdTipoArtigo", "dbo.TipoArtigoes");
            DropForeignKey("dbo.ItemCompras", "IdCompra", "dbo.Compras");
            DropForeignKey("dbo.Compras", "IdUtilizadorFechou", "dbo.Utilizadors");
            DropForeignKey("dbo.Compras", "IdUtilizadorCriacao", "dbo.Utilizadors");
            DropForeignKey("dbo.Orcamentoes", "IdUtilizadorCriacao", "dbo.Utilizadors");
            DropForeignKey("dbo.Orcamentoes", "IdUtilizadorAlteracao", "dbo.Utilizadors");
            DropForeignKey("dbo.ItemCompras", "IdArtigo", "dbo.Artigoes");
            DropIndex("dbo.Orcamentoes", new[] { "IdUtilizadorAlteracao" });
            DropIndex("dbo.Orcamentoes", new[] { "IdUtilizadorCriacao" });
            DropIndex("dbo.Utilizadors", new[] { "Username" });
            DropIndex("dbo.Compras", new[] { "IdUtilizadorFechou" });
            DropIndex("dbo.Compras", new[] { "IdUtilizadorCriacao" });
            DropIndex("dbo.ItemCompras", new[] { "IdArtigo" });
            DropIndex("dbo.ItemCompras", new[] { "IdCompra" });
            DropIndex("dbo.Artigoes", new[] { "IdTipoArtigo" });
            DropTable("dbo.TipoArtigoes");
            DropTable("dbo.Orcamentoes");
            DropTable("dbo.Utilizadors");
            DropTable("dbo.Compras");
            DropTable("dbo.ItemCompras");
            DropTable("dbo.Artigoes");
        }
    }
}
