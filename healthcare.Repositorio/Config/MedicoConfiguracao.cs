using healthcare.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace healthcare.Repositorio.Config
{
    public class MedicoConfiguracao : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.HasKey(m => m.Id);
            builder
                .Property(m => m.Crm)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.Nome)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.Telefone)                
                .HasMaxLength(50);
            builder
                .Property(m => m.ValorConsulta)                
                .HasMaxLength(50);                

        }
    }
}
