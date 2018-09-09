using Loja.Dominio;
using Loja.Repositorios.SqlServer.Migrations;
using Loja.Repositorios.SqlServer.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Loja.Repositorios.SqlServer
{
    // Design pattern: Unit of work
    // Martin Fowler -  padrões de arquitetura de aplicações corporativas
    public class LojaDbContext : IdentityDbContext<Usuario>
    {
        public LojaDbContext() : base("lojaConnectionString")
        {
            //pag 191
            //Database.SetInitializer(new LojaDbInitializer());
            //1. Enable-Migrations
            //2. Update-Database
            //3. Database.SetInitializer abaixo
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<LojaDbContext, Configuration>());

            //4. Add-Migration
            //5. Update-Database
        }

        public static LojaDbContext Create()
        {
            return new LojaDbContext();
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new CategoriaConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
