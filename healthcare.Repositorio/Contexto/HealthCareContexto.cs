using Microsoft.EntityFrameworkCore;
using healthcare.Dominio.Entidades;
using healthcare.Repositorio.Config;
using System.Xml.Linq;

namespace healthcare.Repositorio.Contexto
{
    public class HealthCareContexto : DbContext
    {
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Consultorio> Consultorios { get; set; }
        public DbSet<ConsultorioMedico> ConsultorioMedico { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /// Classes de mapeamento
            modelBuilder.ApplyConfiguration(new MedicoConfiguracao());
            modelBuilder.ApplyConfiguration(new ConsultorioConfiguracao());
            modelBuilder.ApplyConfiguration(new ConsultorioMedicoConfiguracao());

            modelBuilder.Entity<ConsultorioMedico>().HasKey(x => new { x.ConsultorioId, x.MedicoId });

            base.OnModelCreating(modelBuilder);
        }
        public HealthCareContexto(DbContextOptions options) : base(options)
        {
        }

    }
}
