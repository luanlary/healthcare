﻿using healthcare.Dominio.Entidades;

namespace healthcare.Dominio.Contratos
{
    public interface IConsultorioRepositorio: IBaseRepositorio<Consultorio>
    {
        Consultorio ObterPorNome(string nome);
    }
}
