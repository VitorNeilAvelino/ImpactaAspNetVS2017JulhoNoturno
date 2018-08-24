using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class VeiculoRepositorio
    {
        private string _caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            ConfigurationManager.AppSettings["CaminhoArquivoVeiculo"]);

        public void Inserir<T>(T veiculo) //where T: Veiculo
        {
            var arquivoXml = XDocument.Load(_caminhoArquivo);

            var registro = new StringWriter();
            new XmlSerializer(typeof(T)).Serialize(registro, veiculo);

            arquivoXml.Root.Add(XElement.Parse(registro.ToString()));

            arquivoXml.Save(_caminhoArquivo);
        }
    }
}
