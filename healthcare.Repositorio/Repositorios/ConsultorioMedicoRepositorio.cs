using Castle.Components.DictionaryAdapter;
using healthcare.Dominio.Contratos;
using healthcare.Dominio.Entidades;
using healthcare.Repositorio.Contexto;
using System.Linq;

namespace healthcare.Repositorio.Repositorios
{
    public class ConsultorioMedicoRepositorio: BaseRepositorio<ConsultorioMedico>, IConsultorioMedicoRepositorio
    {
        public ConsultorioMedicoRepositorio(HealthCareContexto healthCare) : base(healthCare)
        {


        }

        public int ObterQuantidade(int Id)
        {
            int total = HealthCareContexto.ConsultorioMedico.Count(c => c.MedicoId == Id);
            return total;
        }
    }
}
