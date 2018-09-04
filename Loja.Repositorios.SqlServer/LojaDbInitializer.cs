using System;
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
            var grampeador = new Produto();
            grampeador.Nome = "Grampeador";
            grampeador.Preco = 20.45m;
            grampeador.Estoque = 45;
            grampeador.Descricao = "Grampeador";
            grampeador.Categoria = new Categoria { Nome = "Papelaria" };

            var penDrive = new Produto();
            penDrive.Nome = "Pen drive";
            penDrive.Preco = 20.48m;
            penDrive.Estoque = 48;
            penDrive.Descricao = "Pen drive";
            penDrive.Categoria = new Categoria { Nome = "Informática" };

            return new List<Produto> { grampeador, penDrive };
        }
    }
}