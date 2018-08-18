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
        private string _caminhoArquivo =
            ConfigurationManager.AppSettings["CaminhoArquivoVeiculo"];

        public void Inserir(Veiculo veiculo)
        {
            var arquivoXml = XDocument.Load(_caminhoArquivo);

            var registro = new StringWriter();
            new XmlSerializer(typeof(Veiculo)).Serialize(registro, veiculo);

            arquivoXml.Root.Add(XElement.Parse(registro.ToString()));

            arquivoXml.Save(_caminhoArquivo);
        }
    }
}
