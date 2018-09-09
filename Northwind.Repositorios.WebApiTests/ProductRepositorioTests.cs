using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Northwind.Repositorios.WebApi.Tests
{
    [TestClass()]
    public class ProductRepositorioTests
    {
        ProductRepositorio repositorio = new ProductRepositorio();

        [TestMethod()]
        public void PostTest()
        {
            var produto = new ProductViewModel();
            produto.ProductName = "Cerveja Baden Baden";
            produto.UnitPrice = 16.57m;

            var produtoResponse = repositorio.Post(produto).Result;

            Console.WriteLine(produtoResponse.ProductID);
        }

        [TestMethod()]
        public void PutTest()
        {
            var product = new ProductViewModel();
            product.ProductName = "Café com leite";
            product.UnitsInStock = 49;
            product.UnitPrice = 11.48m;
            product.ProductID = 83;

            repositorio.Put(product.ProductID, product).Wait();

            var response = repositorio.Get(83).Result;

            Assert.AreEqual(response.UnitPrice, 11.48m);
        }

        [TestMethod]
        public void GetTest()
        {
            var produtos = repositorio.Get().Result;

            Assert.IsTrue(produtos.Count > 1);
        }

        [TestMethod]
        public void DeleteTeste()
        {
            repositorio.Delete(83).Wait();

            var produto = repositorio.Get(83).Result;

            Assert.IsNull(produto);
        }
    }
}