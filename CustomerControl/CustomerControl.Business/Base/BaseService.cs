using CustomerControl.Business.Interface.Base;
using CustomerControl.CrossCutting.Exceptions;
using CustomerControl.CrossCutting.Filter.Base;
using CustomerControl.Data.Interface.Base;
using System;
using System.Collections.Generic;

namespace CustomerControl.Business.Base
{
    public class BaseService<T, TFilter> : IServiceBase<T, TFilter> where T : class where TFilter : BaseFilter
    {
        protected readonly IRepositoryBase<T, TFilter> Repository;

        public BaseService(IRepositoryBase<T, TFilter> repository)
        {
            Repository = repository;
        }

        public virtual Guid Create(T dto)
        {
            return Repository.Create(dto);
        }

        public virtual T Update(T dto)
        {
            return Repository.Update(dto);
        }

        public virtual void Remove(Guid id)
        {
            if (Find(id) == null)
                throw new NotFoundException();

            Repository.Remove(id);
        }

        public virtual T Find(Guid id)
        {
            return Repository.Find(id) ?? throw new NotFoundException();
        }

        public virtual List<T> GetAll(TFilter filter)
        {
            return Repository.GetAll(filter);
        }
    }
}