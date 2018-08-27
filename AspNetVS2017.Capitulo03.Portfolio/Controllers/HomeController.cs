using AspNetVS2017.Capitulo03.Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetVS2017.Capitulo03.Portfolio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        //public ActionResult Contact(string nome, string email, string mensagem)
        //public ActionResult Contact(FormCollection formulario)
        public ActionResult Contact(ContatoViewModel contato)
        {
            //var nome = formulario["nome"];

            if (!ModelState.IsValid)
            {
                return View(contato);
            }

            using (var conexao = 
                new SqlConnection(ConfigurationManager.ConnectionStrings["portfolioConnectionString"].ConnectionString))
            {
                conexao.Open();

                const string instrucao = @"
                                                        INSERT INTO [dbo].[Contato]
                                                                   ([Nome]
                                                                   ,[Email]
                                                                   ,[Mensagem])
                                                             VALUES
                                                                   (@Nome
                                                                   ,@Email
                                                                   ,@Mensagem)
                                                        ";

                using (var comando = new SqlCommand(instrucao, conexao))
                {
                    comando.Parameters.AddWithValue("@Nome", contato.Nome);
                    comando.Parameters.AddWithValue("@Email", contato.Email);
                    comando.Parameters.AddWithValue("@Mensagem", contato.Mensagem);

                    comando.ExecuteNonQuery();

                    ViewBag.Sucesso = true;
                }

                //conexao.Close();
            }

            ModelState.Clear();

            return View();
        }
    }
}