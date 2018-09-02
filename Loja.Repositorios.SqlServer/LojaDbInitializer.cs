using System.Collections.Generic;
using System.Data.Entity;
using Loja.Dominio;

namespace Loja.Repositorios.SqlServer
{
    internal class LojaDbInitializer : DropCreateDatabaseIfModelChanges<LojaDbContext>
    {
        protected override void Seed(LojaDbContext context)
        {
            context.Produtos.AddRange(ObterProdutos());

            context.SaveChanges();

            base.Seed(context); 
        }

        private IEnumerable<Produto> ObterProdutos()
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