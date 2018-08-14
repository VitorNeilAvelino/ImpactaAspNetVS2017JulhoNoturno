using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AspNetVS2017.Capitulo01.VetoresColecoes.Testes
{
    [TestClass]
    public class VetoresTeste
    {
        [TestMethod]
        public void InicializacaoTeste()
        {
            var strings = new string[10];

            int[] inteiros = new int[5];
            inteiros[0] = 9;
            inteiros[4] = 2;

            //Assert.IsNull(inteiros[1]);
            Assert.AreEqual(inteiros[1], 0);

            var decimais = new decimal[] { 0.3m, 0.2m, 7m };

            decimal[] outroVetor = { 0.5m, 8.6m, 12};

            foreach (var @decimal in decimais)
            {
                Console.WriteLine(@decimal);
            }

            Console.WriteLine("Tamanho do vetor:" + decimais.Length);
        }
    }
}
