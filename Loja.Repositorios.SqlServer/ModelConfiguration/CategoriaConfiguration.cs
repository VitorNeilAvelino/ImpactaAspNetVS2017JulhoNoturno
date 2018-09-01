using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositorios.SqlServer.ModelConfiguration
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            //HasKey(p => p., );

            //ToTable("tbCategoria");

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}