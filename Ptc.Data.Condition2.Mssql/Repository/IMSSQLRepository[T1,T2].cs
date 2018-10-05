using Ptc.Data.Condition2.Common;
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
    public interface IMSSQLRepository<TSource, TDistinct> : IRepository where TSource : class , new()
    {


        TDistinct Add(TDistinct domain);

        TOutput Add<TOutput>(TDistinct domain, Func<TDistinct,TSource> mapper1, Func<TSource, TOutput> mapper2);

        TDistinct Add(MSSQLCondition<TSource> conditions, TDistinct domain);

        TOutput Add<TOutput>(MSSQLCondition<TSource> conditions, TDistinct domain, Func<TDistinct,TSource> mapper1, Func<TSource, TOutput> mapper2);

        IEnumerable<TDistinct> AddRange(List<TDistinct> domains);

        IEnumerable<TOutput> AddRange<TOutput>(List<TDistinct> domains, Func<TDistinct, TSource> mapper1, Func<TSource, TOutput> mapper2);

        TDistinct Get(MSSQLCondition<TSource> conditions);

        TDistinct Get(MSSQLCondition<TSource> conditions, Func<TSource,TDistinct> mapper);

        TDistinct Get(params Expression<Func<TSource, bool>>[] filters);

        TDistinct Get(Func<TSource,TDistinct> mapper, params Expression<Func<TSource, bool>>[] filters);

        IEnumerable<TDistinct> GetList(MSSQLCondition<TSource> conditions);

        IEnumerable<TDistinct> GetList(MSSQLCondition<TSource> conditions, Func<TSource,TDistinct> mapper);

        IEnumerable<TDistinct> GetList(params Expression<Func<TSource, bool>>[] filters);


        IEnumerable<TDistinct> GetList(Func<TSource , TDistinct> mapper, params Expression<Func<TSource, bool>>[] filters);

        PagedList<TDistinct> GetPaging(MSSQLCondition<TSource> conditions);

        PagedList<TDistinct> GetPaging(MSSQLCondition<TSource> conditions, Func<TSource,TDistinct> mapper);

        Boolean HasAny(MSSQLCondition<TSource> conditions);

        Boolean HasAny(params Expression<Func<TSource, bool>>[] filters);

        Boolean Remove(MSSQLCondition<TSource> conditions);

        Boolean RemoveRange(MSSQLCondition<TSource> conditions);

        TDistinct Update(MSSQLCondition<TSource> conditions, TDistinct domain, Func<TDistinct, TSource> mapper1 = null, Func<TSource, TDistinct> mapper2 = null);

        void Operator(Action<IDisposable> func);

        TDistinct Operator(Func<IDisposable, TDistinct> func);

        List<TDistinct> GetListOfSpecific(MSSQLCondition<TSource> conditions, Expression<Func<TSource, TDistinct>> selector);

        TDistinct GetOfSpecific(MSSQLCondition<TSource> conditions, Expression<Func<TSource, TDistinct>> selector);
    }
}
