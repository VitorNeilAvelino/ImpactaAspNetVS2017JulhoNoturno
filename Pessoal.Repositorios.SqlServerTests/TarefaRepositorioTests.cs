using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pessoal.Dominio;
using Pessoal.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pessoal.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class TarefaRepositorioTests
    {
        private TarefaRepositorio _tarefaRepositorio = new TarefaRepositorio();

        [TestMethod()]
        public void InserirTest()
        {
            var tarefa = new Tarefa();

            //tarefa.Concluida = Convert.ToBoolean(0);
            //tarefa.Concluida = Convert.ToBoolean("true");
            //tarefa.Concluida = false;
            tarefa.Concluida = false;
            tarefa.Nome = "Passar roupa";
            tarefa.Observacoes = "Muita roupa";
            tarefa.Prioridade = Prioridade.Alta;

            _tarefaRepositorio.Inserir(tarefa);
        }

        [TestMethod()]
        public void AtualizarTest()
        {
            var tarefa = _tarefaRepositorio.Selecionar().First();

            tarefa.Concluida = true;
            tarefa.Nome = "Roupa passada";
            tarefa.Observacoes = "Obs";
            tarefa.Prioridade = Prioridade.Baixa;

            _tarefaRepositorio.Atualizar(tarefa);
        }

        [TestMethod()]
        public void ExcluirTest()
        {
            _tarefaRepositorio.Excluir(6);

            var tarefaExcluida = _tarefaRepositorio.Selecionar(6);
            var tarefa = _tarefaRepositorio.Selecionar(5);

            Assert.IsNull(tarefaExcluida);
            Assert.IsNotNull(tarefa);
        }
    }
}