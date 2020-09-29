using healthcare.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace healthcare.Repositorio.Config
{
    public class ConsultorioConfiguracao : IEntityTypeConfiguration<Consultorio>
    {
    
        public void Configure(EntityTypeBuilder<Consultorio> builder)
        {
            builder.HasKey(c => c.Id);
            builder
                .Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(c => c.Endereco)
                .IsRequired()
                .HasMaxLength(150);
            builder
                .Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);          
        }
    }
}
