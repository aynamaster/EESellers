namespace EESellers.Migrations
{
    using EESellers.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EESellers.Models.DbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EESellers.Models.DbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Produtos.AddOrUpdate(
                new Produto() { dsProduto = "Seguro Casa", vlrUnitario = 5000, qtdEstoque = 999 },
                new Produto() { dsProduto = "Seguro Carro", vlrUnitario = 2000, qtdEstoque = 999 },
                new Produto() { dsProduto = "Seguro Empresa", vlrUnitario = 10000, qtdEstoque = 999 },
                new Produto() { dsProduto = "Seguro Vida", vlrUnitario = 800, qtdEstoque = 999 }

                );

            context.Vendedores.AddOrUpdate(
                new Vendedor() { dsVendedor = "Carlos", vlrSaldo = "2000" },
                new Vendedor() { dsVendedor = "João", vlrSaldo = "500" },
                new Vendedor() { dsVendedor = "Maria", vlrSaldo = "100" }
                );

            context.Vendas.AddOrUpdate(
                 new Vendas() { cdVendedor = 1, cdProduto = 2 }
                 );
        }
    }
}
