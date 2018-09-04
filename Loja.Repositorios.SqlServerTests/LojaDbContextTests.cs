using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Loja.Dominio;
using System.Data.Entity;


namespace Loja.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class LojaDbContextTests
    {
        private LojaDbContext db = new LojaDbContext();

        public LojaDbContextTests()
        {
            db.Database.Log = LogarQuery;
        }

        private void LogarQuery(string query)
        {
            Debug.WriteLine(query);
        }

        [TestMethod()]
        public void InserirCategoriaTeste()
        {
            var papelaria = new Categoria();
            papelaria.Nome = "Papelaria";

            db.Categorias.Add(papelaria);

            var informatica = new Categoria();
            informatica.Nome = "Informática";

            db.Categorias.Add(informatica);

            db.SaveChanges();
        }

        [TestMethod]
        public void InserirProduto()
        {
            var caneta = new Produto();
            caneta.Estoque = 55;
            caneta.Nome = "Caneta";
            caneta.Preco = 21.55m;
            caneta.Categoria = db.Categorias.Find(1);

            db.Produtos.Add(caneta);

            var barbeador = new Produto();
            barbeador.Estoque = 2;
            barbeador.Nome = "Barbeador";
            barbeador.Preco = 22.02m;
            barbeador.Categoria = new Categoria(){ Nome = "Perfumaria" };

            db.Produtos.Add(barbeador);

            db.SaveChanges();
        }

        [TestMethod]
        public void EditarProdutoTeste()
        {
            //Linq
            var caneta = db.Produtos
                .FirstOrDefault(produto => produto.Nome == "Caneta");
            //.Where(produto => produto.Nome == "Caneta").ToList();

            caneta.Preco = 22.32m;

            db.SaveChanges();
        }

        [TestMethod]
        public void ExcluirProdutoTeste()
        {
            var caneta = db.Produtos.SingleOrDefault(p => p.Id == 2);

            db.Produtos.Remove(caneta);

            db.SaveChanges();

            caneta = db.Produtos.SingleOrDefault(p => p.Id == 2);

            Assert.IsNull(caneta);
        }

        [TestMethod]
        public void LazyLoadDesligadoTeste()
        {
            var caneta = db.Produtos
                .SingleOrDefault(p => p.Nome == "Caneta");

            Assert.IsNull(caneta.Categoria);

            //Console.WriteLine(caneta.Categoria.Nome);
        }

        [TestMethod]
        public void LazyLoadLigadoTeste()
        {
            // habilitar o modificador virtual nas propriedades
            // complexas.

            var caneta = db.Produtos
                .SingleOrDefault(p => p.Nome == "Caneta");

            Assert.IsNotNull(caneta.Categoria);

            Console.WriteLine(caneta.Categoria.Nome);
        }

        [TestMethod]
        public void IncludeTeste()
        {
            var caneta = db.Produtos
                .Include(p => p.Categoria)
                .SingleOrDefault(p => p.Nome == "Caneta");

            Assert.IsTrue(caneta.Categoria.Nome == "Papelaria");
        }

        [TestMethod]
        public void QueryableTeste()
        {
            var query = db.Produtos.Where(p => p.Preco > 10);

            if (true)
            {
                query = query.Where(p => p.Estoque > 5);
            }

            query = query.OrderBy(p => p.Nome);

            var todos = query.ToList();
            //var unico = query.Single();
            //var primeiro = query.First();
            //var ultimo = query.AsEnumerable().Last();
        }
    }
}