using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class ModeloRepositorioTests
    {
        [TestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        public void SelecionarPorMarcaTest(int marcaId)
        {
            var modelos = new ModeloRepositorio().SelecionarPorMarca(marcaId);

            foreach (var modelo in modelos)
            {
                Console.WriteLine($"{modelo.Id}: {modelo.Nome} - {modelo.Marca.Nome}");
            }
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(-1)]
        public void SelecionarTest(int id)
        {
            var modelo = new ModeloRepositorio().Selecionar(id);

            if (id > 0)
            {
                Assert.AreEqual(modelo.Nome, "Mobi");
            }
            else
            {
                Assert.IsNull(modelo);
            }
        }
    }
}