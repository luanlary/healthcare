using healthcare.Dominio.Entidades;

namespace healthcare.Dominio.Contratos
{
    public interface IMedicoRepositorio : IBaseRepositorio<Medico>
    {
        Medico ObterPorCRM(string CRM);
    }
}
