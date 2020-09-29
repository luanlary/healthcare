using healthcare.Dominio.Contratos;
using healthcare.Repositorio.Contexto;
using System.Collections.Generic;
using System.Linq;

namespace healthcare.Repositorio.Repositorios
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        protected readonly HealthCareContexto HealthCareContexto;
        public BaseRepositorio(HealthCareContexto healthcare)
        {
            HealthCareContexto = healthcare;
        }
        public void Adicionar(TEntity entity)
        {
            HealthCareContexto.Set<TEntity>().Add(entity);
            HealthCareContexto.SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            HealthCareContexto.Set<TEntity>().Update(entity);
            HealthCareContexto.SaveChanges();
        }

        public TEntity ObterPorId(int id)
        {
            return HealthCareContexto.Set<TEntity>().Find(id);
        }

        IEnumerable<TEntity> IBaseRepositorio<TEntity>.ObterTodos()
        {
            return HealthCareContexto.Set<TEntity>().ToList<TEntity>();
        }
        public void Remover(TEntity entity)
        {
            HealthCareContexto.Set<TEntity>().Remove(entity);
            HealthCareContexto.SaveChanges();
        }
        public void Dispose()
        {
            HealthCareContexto.Dispose();
        }
       
    }
}