using Microsoft.EntityFrameworkCore;
using NovoProjeto.Domain.Interface;
using NovoProjeto.Domain.Interface.Repository;
using NovoProjeto.Domain.Models;
using NovoProjeto.Infra.Data.Context;
using System;
using System.Linq;

namespace NovoProjeto.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly NovoProjetoContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository( NovoProjetoContext context )
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Incluir( TEntity entity )
        {
            _dbSet.Add( entity );
        }

        public TEntity Consultar( Guid id )
        {
            return _dbSet
                .AsNoTracking()
                .Where( x => x.ID == id && x.Validacao )
                .FirstOrDefault();
        }

        public IQueryable<TEntity> Listar()
        {
            return _dbSet
                .AsNoTracking()
                .OrderBy( x => x.DataInclusao )
                .Where( x => x.Validacao );
        }

        public void Alterar( TEntity entity )
        {
            entity.DataAlteracao = DateTime.Now;
            _dbSet.Update( entity );
        }

        public void Remover( Guid id )
        {
            TEntity entity = _dbSet.Find( id );
            entity.Validacao = false;
            entity.DataAlteracao = DateTime.Now;

            _dbSet.Update( entity );
        }

        public bool Salvar()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize( this );
        }
    }
}
