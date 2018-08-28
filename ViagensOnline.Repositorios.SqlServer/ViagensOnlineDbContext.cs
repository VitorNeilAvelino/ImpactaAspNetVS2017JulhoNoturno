using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ViagensOnline.Dominio;

namespace ViagensOnline.Repositorios.SqlServer
{
    // Hibernate - Java
    public class ViagensOnlineDbContext : DbContext
    {
        public ViagensOnlineDbContext() : base("viagensOnlineConnectionString")
        {

        }

        public DbSet<Destino> Destinos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}