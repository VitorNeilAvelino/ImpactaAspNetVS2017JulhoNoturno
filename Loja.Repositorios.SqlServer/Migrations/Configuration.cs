namespace Loja.Repositorios.SqlServer.Migrations
{
    using Loja.Dominio;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<LojaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Loja.Repositorios.SqlServer.LojaDbContext";
        }

        protected override void Seed(LojaDbContext context)
        {
            context.Produtos.AddRange(ObterProdutos());

            context.SaveChanges();

            base.Seed(context);
        }

        private List<Produto> ObterProdutos()
        {
            var barbeador = new Produto();
            barbeador.Estoque = 2;
            barbeador.Nome = "Barbeador";
            barbeador.Preco = 22.02m;
            barbeador.Ativo = true;
            barbeador.Categoria = new Categoria() { Nome = "Perfumaria" };

            var camiseta = new Produto();
            camiseta.Estoque = 19;
            camiseta.Nome = "Camiseta";
            camiseta.Preco = 17.19m;
            barbeador.Ativo = true;
            camiseta.Categoria = new Categoria() { Nome = "Confecção" };

            return new List<Produto> { barbeador, camiseta };
        }
    }
}