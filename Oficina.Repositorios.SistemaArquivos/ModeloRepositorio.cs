using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class ModeloRepositorio
    {
        private string _caminhoArquivo =
            ConfigurationManager.AppSettings["CaminhoArquivoModelo"];

        private MarcaRepositorio _marcaRepositorio = new MarcaRepositorio();

        public List<Modelo> SelecionarPorMarca(int marcaId)
        {
            var arquivoXml = XDocument.Load(_caminhoArquivo);
            var modelos = new List<Modelo>();
            
            foreach (var elemento in arquivoXml.Descendants("modelo"))
            {
                if (marcaId.ToString() == elemento.Element("marcaId").Value)
                {
                    var modelo = new Modelo();

                    modelo.Id = Convert.ToInt32(elemento.Element("id").Value);
                    modelo.Nome = elemento.Element("nome").Value;
                    modelo.Marca = _marcaRepositorio.Selecionar(marcaId);

                    modelos.Add(modelo);
                }
            }

            return modelos;
        }

        public Modelo Selecionar(int id)
        {
            Modelo modelo = null;
            var arquivoXml = XDocument.Load(_caminhoArquivo);

            foreach (var elemento in arquivoXml.Descendants("modelo"))
            {
                if (id.ToString() == elemento.Element("id").Value)
                {
                    modelo = new Modelo();

                    modelo.Id = Convert.ToInt32(elemento.Element("id").Value);
                    modelo.Nome = elemento.Element("nome").Value;
                    modelo.Marca = 
                        _marcaRepositorio.Selecionar(Convert.ToInt32(elemento.Element("marcaId").Value));

                    break;
                }
            }

            return modelo;
        }
    }
}
