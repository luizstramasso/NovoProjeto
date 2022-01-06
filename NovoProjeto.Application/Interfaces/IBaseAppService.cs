using System;
using System.Linq;

namespace NovoProjeto.Application.Interfaces
{
    public interface IBaseAppService<TViewEntity>
    {
        bool Incluir( TViewEntity entity );
        TViewEntity Consultar( Guid id );
        IQueryable<TViewEntity> Listar();
        bool Alterar( TViewEntity entity );
        bool Remover( Guid id );
    }
}
