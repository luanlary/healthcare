using healthcare.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace healthcare.Repositorio.Config
{
    public class ConsultorioMedicoConfiguracao : IEntityTypeConfiguration<ConsultorioMedico>
    {
        
        public void Configure(EntityTypeBuilder<ConsultorioMedico> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.ConsultorioId)
                .IsRequired();

            builder
                .Property(c => c.MedicoId)
                .IsRequired();
                
        }
    }
}
