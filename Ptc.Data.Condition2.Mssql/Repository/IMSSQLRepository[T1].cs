using Ptc.Data.Condition2.Common.Class;
using Ptc.Data.Condition2.Interface.Repository;
using Ptc.Data.Condition2.Mssql.Class;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Mssql.Repository
{
    public interface IMSSQLRepository<TSource> : IRepository where TSource : class , new()
    {

        TSource Add(TSource entity);

        TSource Add(MSSQLCondition<TSource> conditions, TSource entity);

        IEnumerable<TSource> AddRange(List<TSource> entities);

        TSource Get(MSSQLCondition<TSource> conditions);

        TSource Get(params Expression<Func<TSource, bool>>[] filters);

        IEnumerable<TSource> GetList(MSSQLCondition<TSource> conditions);

        IEnumerable<TSource> GetList(params Expression<Func<TSource, bool>>[] filters);

        PagedList<TSource> GetPaging(MSSQLCondition<TSource> conditions);

        Boolean HasAny(MSSQLCondition<TSource> conditions);

        Boolean HasAny(params Expression<Func<TSource, bool>>[] filters);

        Boolean Remove(MSSQLCondition<TSource> conditions);

        Boolean RemoveRange(MSSQLCondition<TSource> conditions);

        TSource Update(MSSQLCondition<TSource> conditions, TSource entity);

        void Operator(Action<IDisposable> func);

        TSource Operator(Func<IDisposable, TSource> func);

        TDistinct GetOfSpecific<TDistinct>(MSSQLCondition<TSource> conditions, Expression<Func<TSource, TDistinct>> selector);

        List<TDistinct> GetListOfSpecific<TDistinct>(MSSQLCondition<TSource> conditions, Expression<Func<TSource, TDistinct>> selector);

    }
}
