using healthcare.Dominio.Contratos;
using healthcare.Dominio.Entidades;
using healthcare.Repositorio.Contexto;
using System.Linq;

namespace healthcare.Repositorio.Repositorios
{
    public class ConsultorioRepositorio: BaseRepositorio<Consultorio>, IConsultorioRepositorio
    {
        public ConsultorioRepositorio(HealthCareContexto healthCare) : base(healthCare)
        {

        }

        public Consultorio ObterPorNome(string nome)
        {
            return HealthCareContexto.Consultorios.FirstOrDefault(c => c.Nome == nome);
        }
    }
}
