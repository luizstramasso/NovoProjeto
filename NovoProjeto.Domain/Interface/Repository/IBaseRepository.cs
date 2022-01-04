using System;
using System.Linq;

namespace NovoProjeto.Domain.Interface.Repository
{
    public interface IBaseRepository<TEntity> : IDisposable
    {
        void Incluir( TEntity entity );
        TEntity Consultar( Guid id );
        IQueryable<TEntity> Listar();
        void Alterar( TEntity entity );
        void Remover( Guid id );
        bool Salvar();
    }
}
