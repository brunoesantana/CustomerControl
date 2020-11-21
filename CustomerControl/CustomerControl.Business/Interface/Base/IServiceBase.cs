using CustomerControl.CrossCutting.Filter.Base;
using System;
using System.Collections.Generic;

namespace CustomerControl.Business.Interface.Base
{
    public interface IServiceBase<T, TFilter> where T : class where TFilter : BaseFilter
    {
        Guid Create(T dto);

        T Update(T dto);

        void Remove(Guid id);

        T Find(Guid id);

        List<T> GetAll(TFilter filter);
    }
}