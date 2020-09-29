using healthcare.Dominio.Entidades;
using healthcare.Dominio.Contratos;
using healthcare.Repositorio.Contexto;

namespace healthcare.Repositorio.Repositorios
{
    public class MedicoRepositorio : BaseRepositorio<Medico>, IMedicoRepositorio
    {
        public MedicoRepositorio(HealthCareContexto healthCare) : base(healthCare)
        {

        }
    }
}
