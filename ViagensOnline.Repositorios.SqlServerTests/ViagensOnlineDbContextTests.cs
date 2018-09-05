using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViagensOnline.Dominio;

namespace ViagensOnline.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class ViagensOnlineDbContextTests
    {
        private ViagensOnlineDbContext _db = new ViagensOnlineDbContext();

        [TestMethod()]
        public void InserirTeste()
        {
            var destino = new Destino();

            destino.Cidade = "Londres";
            destino.Nome = "Conheça a terra da Rainha";
            destino.NomeImagem = "Londres.jpg";
            destino.Pais = "Inglaterra";

            _db.Destinos.Add(destino);

            _db.SaveChanges();
        }

        [TestMethod]
        public void AtualizarTeste()
        {
            //Linq
            var destino = _db.Destinos.Find(1);

            destino.Pais = "England";

            _db.SaveChanges();
        }

        [TestMethod]
        public void ExcluirTeste()
        {
            var destino = _db.Destinos.Find(1);

            _db.Destinos.Remove(destino);

            _db.SaveChanges();
        }
    }
}