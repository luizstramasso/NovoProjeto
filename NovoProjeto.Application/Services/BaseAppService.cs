using AutoMapper;
using AutoMapper.QueryableExtensions;
using NovoProjeto.Application.Interfaces;
using NovoProjeto.Domain.Interface;
using NovoProjeto.Domain.Interface.Repository;
using NovoProjeto.Infra.CrossCutting.Util.ViewEntity;
using System;
using System.Linq;

namespace NovoProjeto.Application.Services
{
    public class BaseAppService<TEntity, TViewEntity> : IBaseAppService<TViewEntity> where TViewEntity : BaseViewEntity
    {
        protected readonly IMapper _mapper;
        protected readonly IBaseRepository<TEntity> _repository;

        public BaseAppService( IMapper mapper, IBaseRepository<TEntity> repository )
        {
            _mapper = mapper;
            _repository = repository;
        }

        public bool Incluir( TViewEntity entity )
        {
            if( entity.ID == Guid.Empty )
            {
                entity.ID = Guid.NewGuid();
            }

            entity.DataInclusao = DateTime.Now;

            _repository.Incluir( _mapper.Map<TEntity>( entity ) );

            return _repository.Salvar();
        }

        public IQueryable<TViewEntity> Listar()
        {
            return _repository.Listar().ProjectTo<TViewEntity>( _mapper.ConfigurationProvider );

        }

        public TViewEntity Consultar( Guid id )
        {
            return _mapper.Map<TViewEntity>( _repository.Consultar( id ) );
        }

        public bool Alterar( TViewEntity entity )
        {
            entity.DataAlteracao = DateTime.Now;

            _repository.Alterar( _mapper.Map<TEntity>( entity ) );
            return _repository.Salvar();
        }

        public bool Remover( Guid id )
        {
            _repository.Remover( id );
            return _repository.Salvar();
        }
    }
}
