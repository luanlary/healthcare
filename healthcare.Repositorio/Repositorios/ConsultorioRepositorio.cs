using healthcare.Dominio.Contratos;
using healthcare.Dominio.Entidades;
using healthcare.Repositorio.Contexto;

namespace healthcare.Repositorio.Repositorios
{
    public class ConsultorioRepositorio: BaseRepositorio<Consultorio>, IConsultorioRepositorio
    {
        public ConsultorioRepositorio(HealthCareContexto healthCare) : base(healthCare)
        {

        }
    }
}
