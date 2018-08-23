using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace AspNetVS2017.Capitulo02.Http.Testes
{
    [TestClass]
    public class HttpTeste
    {
        [TestMethod]
        public void RequestGetTeste()
        {
            var request = (HttpWebRequest)WebRequest
                .Create("http://www.example.com?usuarioId=42&cpf=123456");

            request.Method = "GET";
            request.UserAgent = "Visual Studio";
            request.Date = DateTime.Now;
        }
    }
}
