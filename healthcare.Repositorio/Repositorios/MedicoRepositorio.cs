using healthcare.Dominio.Entidades;
using healthcare.Dominio.Contratos;
using healthcare.Repositorio.Contexto;
using System.Linq;

namespace healthcare.Repositorio.Repositorios
{
    public class MedicoRepositorio : BaseRepositorio<Medico>, IMedicoRepositorio
    {
        public MedicoRepositorio(HealthCareContexto healthCare) : base(healthCare)
        {

        }

        public Medico ObterPorCRM(string CRM)
        {
           return  HealthCareContexto.Medicos.FirstOrDefault(m => m.Crm == CRM);
        }
    }
}
