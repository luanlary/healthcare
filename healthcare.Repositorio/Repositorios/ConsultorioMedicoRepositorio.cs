using healthcare.Dominio.Contratos;
using healthcare.Dominio.Entidades;
using healthcare.Repositorio.Contexto;

namespace healthcare.Repositorio.Repositorios
{
    public class ConsultorioMedicoRepositorio: BaseRepositorio<ConsultorioMedico>, IConsultorioMedicoRepositorio
    {
        public ConsultorioMedicoRepositorio(HealthCareContexto healthCare) : base(healthCare)
        {


        }
    }
}
