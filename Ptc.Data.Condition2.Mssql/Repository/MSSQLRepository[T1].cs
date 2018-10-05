using AutoMapper;
using LinqKit;
using Ptc.Data.Condition2.Common;
using Ptc.Data.Condition2.Common.Class;
using Ptc.Data.Condition2.Interface.Common;
using Ptc.Data.Condition2.Interface.Type;
using Ptc.Data.Condition2.Mssql.Class;
using Ptc.Data.Condition2.Mssql.Common;
using Ptc.Data.Condition2.Mssql.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Mssql.Repository
{
    public class MSSQLRepository<TSource> : IMSSQLRepository<TSource> where TSource : class , new()
    {
        private Func<IDisposable> contextDelegate;
        private Func<IMapper> mapperDelegate;

        public MSSQLRepository()
        {
            ISetup config = GetConfig();
            this.contextDelegate = GetContextDelegate(config);
            this.mapperDelegate = GetMapperDelegate(config);

        }

        private ISetup GetConfig()
        {
            var config = DataAccessConfiguration.GetConfig(DBStructureType.MSSQL);

            if (config == null)
                throw new NullReferenceException("[PTC_DATA] MSSQL MODE 未設定");

            return config;

        }

        private Func<IMapper> GetMapperDelegate(ISetup config)
        {
            return config.DefaultMappingConfig;
        }

        private Func<IDisposable> GetContextDelegate(ISetup config)
        {

            var contextDelegate = config.CastTo<MSSQLDataSetting>().DefaultDBContextDelegate;

            if (contextDelegate == null)
                throw new NullReferenceException("[PTC_DATA] MSSQL MODE 未設定");

            return contextDelegate;
        }

        public void OverrideDBContext(Func<IDisposable> func)
        {
            this.contextDelegate = func;
        }


        public TSource Add(TSource entity)
        {
            using (var context = (DbContext)contextDelegate())
            {

                context.Configuration.LazyLoadingEnabled = false;

                context.Set<TSource>().Add(entity);

                context.SaveChanges();

                return entity;
            }
        }

        public TSource Add(MSSQLCondition<TSource> conditions, TSource entity)
        {
            using (var context = (DbContext)contextDelegate())
            {
                context.Configuration.LazyLoadingEnabled = false;


                foreach (var w in conditions.GetModifies())
                {
                    SetEntitySatateWhenAdd(context, entity, w.Expression, w.EntityState);
                }

                context.Set<TSource>().Add(entity);

                context.SaveChanges();

                return entity;
            }
        }

        public IEnumerable<TSource> AddRange(List<TSource> entities)
        {
            using (var context = (DbContext)contextDelegate())
            {

                context.Configuration.LazyLoadingEnabled = false;

                context.Set<TSource>().AddRange(entities);

                context.SaveChanges();

                return entities;
            }
        }

        public TSource Get(MSSQLCondition<TSource> conditions)
        {
            using (var context = (DbContext)contextDelegate())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var query = context.Set<TSource>()
                                   .AsQueryable()
                                   .AsNoTracking();


                foreach (var e in conditions.GetIncludes())
                {
                    query = query.Include(e);
                }


                query = query.AsExpandable()
                             .Where(ConditionUtility.GetPredicate(conditions.GetFilters()));


                return query.SingleOrDefault();
            }
        }

        public TSource Get(params Expression<Func<TSource, bool>>[] filters)
        {
            using (var context = (DbContext)contextDelegate())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var query = context.Set<TSource>()
                                   .AsQueryable()
                                   .AsNoTracking();


                foreach (var e in filters)
                {
                    query = query.Where(e);
                }

                return query.SingleOrDefault();
            }
        }

        public IEnumerable<TSource> GetList(MSSQLCondition<TSource> conditions)
        {
            using (var context = (DbContext)contextDelegate())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var query = context.Set<TSource>()
                                   .AsQueryable()
                                   .AsNoTracking();


                foreach (var e in conditions.GetIncludes())
                {
                    query = query.Include(e);
                }


                query = query.AsExpandable()
                             .Where(ConditionUtility.GetPredicate(conditions.GetFilters()));

                var pe = conditions.GetPrimary();

                query = query.OrderBy(pe.Expression, pe.OrderType);

                foreach (var oe in conditions.GetOthers())
                {
                    query = query.ThenBy(oe.Expression, oe.OrderType);
                }

                conditions.TotalCount = query.Count();

                return query.ToList();
            }
        }

        public IEnumerable<TSource> GetList(params Expression<Func<TSource, bool>>[] filters)
        {
            using (var context = (DbContext)contextDelegate())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var query = context.Set<TSource>()
                                   .AsQueryable()
                                   .AsNoTracking();

                foreach (var e in filters)
                {
                    query = query.Where(e);
                }

                return query.ToList();
            }
        }

        public PagedList<TSource> GetPaging(MSSQLCondition<TSource> conditions)
        {
            using (var context = (DbContext)contextDelegate())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var query = context.Set<TSource>()
                                   .AsQueryable()
                                   .AsNoTracking();


                foreach (var e in conditions.GetIncludes())
                {
                    query = query.Include(e);
                }


                query = query.AsExpandable()
                             .Where(ConditionUtility.GetPredicate(conditions.GetFilters()));

                conditions.TotalCount = query.Count();


                var pe = conditions.GetPrimary();

                query = query.OrderBy(pe.Expression, pe.OrderType);

                foreach (var oe in conditions.GetOthers())
                {
                    query = query.ThenBy(oe.Expression, oe.OrderType);
                }

                if (conditions.PageSize > 0)
                {
                    query = query.Skip(conditions.PageSize * conditions.PageIndex)
                                 .Take(conditions.PageSize);
                }

           
                return new PagedList<TSource>(query,
                                              conditions.PageIndex,
                                              conditions.PageSize,
                                              conditions.TotalCount);
            }
        }

        public TSource Update(MSSQLCondition<TSource> conditions, TSource entity)
        {
            using (var context = (DbContext)contextDelegate())
            {

                context.Configuration.LazyLoadingEnabled = false;

                var query = context.Set<TSource>()
                                   .AsQueryable()
                                   .AsExpandable()
                                   .Where(ConditionUtility.GetPredicate(conditions.GetFilters()));
                foreach (var e in conditions.GetIncludes())
                {
                    query = query.Include(e);
                }

                var tracker = query.FirstOrDefault();

        
                foreach (var w in conditions.GetModifies())
                {
                    DoUpdate(context, w.Expression, tracker, entity, w.EntityState);

                }
                
                context.SaveChanges();

                return tracker;
            }
        }

        public TSource Operator(Func<IDisposable, TSource> func)
        {
            using (var context = (DbContext)contextDelegate())
            {
                return func(context);
            }
        }

        public Boolean Remove(MSSQLCondition<TSource> conditions)
        {
            using (var context = (DbContext)contextDelegate())
            {

                context.Configuration.LazyLoadingEnabled = false;

                var query = context.Set<TSource>().AsQueryable();

                conditions.GetIncludes()?.ForEach(x => query = query.Include(x));

                query = query.AsExpandable().Where(ConditionUtility.GetPredicate(conditions.GetFilters()));

                var result = query.SingleOrDefault();

                if (result == null) { throw new NullReferenceException($"[REMOVE] error. data is not found : {typeof(TSource)} ."); }

                context.Set<TSource>().Remove(result);

                return context.SaveChanges() > 0;
            }
        }

        public Boolean RemoveRange(MSSQLCondition<TSource> conditions)
        {
            using (var context = (DbContext)contextDelegate())
            {

                context.Configuration.LazyLoadingEnabled = false;

                var query = context.Set<TSource>().AsQueryable();

                conditions.GetIncludes()?.ForEach(x => query = query.Include(x));

                query = query.AsExpandable().Where(ConditionUtility.GetPredicate(conditions.GetFilters()));

                if (!query.Any()) { throw new NullReferenceException($"[REMOVE] error. data is not found : {typeof(TSource)} ."); }

                context.Set<TSource>().RemoveRange(query);

                return context.SaveChanges() > 0;
            }
        }

        public void Operator(Action<IDisposable> func)
        {
            using (var context = (DbContext)contextDelegate())
            {
                func(context);
            }
        }

        public bool HasAny(MSSQLCondition<TSource> conditions)
        {
            using (var context = (DbContext)contextDelegate())
            {

                context.Configuration.LazyLoadingEnabled = false;

                var query = context.Set<TSource>()
                                   .AsQueryable()
                                   .AsNoTracking();

                foreach (var e in conditions.GetIncludes())
                {
                    query = query.Include(e);
                }

                query = query.AsExpandable().Where(ConditionUtility.GetPredicate(conditions.GetFilters()));

                return query.Any();
            }
        }

        public bool HasAny(params Expression<Func<TSource, bool>>[] filters)
        {
            using (var context = (DbContext)contextDelegate())
            {

                context.Configuration.LazyLoadingEnabled = false;

                var query = context.Set<TSource>()
                                   .AsQueryable()
                                   .AsNoTracking();

                foreach (var e in filters)
                {
                    query = query.Where(e);
                }

                return query.Any();
            }
        }

        public List<TDistinct> GetListOfSpecific<TDistinct>(MSSQLCondition<TSource> conditions, Expression<Func<TSource, TDistinct>> selector)
        {
            using (var context = (DbContext)contextDelegate())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var query = context.Set<TSource>()
                                   .AsQueryable()
                                   .AsNoTracking();


                foreach (var e in conditions.GetIncludes())
                {
                    query = query.Include(e);
                }


                query = query.AsExpandable()
                             .Where(ConditionUtility.GetPredicate(conditions.GetFilters()));

                var pe = conditions.GetPrimary();

                query = query.OrderBy(pe.Expression, pe.OrderType);

                foreach (var oe in conditions.GetOthers())
                {
                    query = query.ThenBy(oe.Expression, oe.OrderType);
                }


                conditions.TotalCount = query.Count();

                var result = query.Select(selector.Compile()).ToList();

                return result;
            }
        }

        public TDistinct GetOfSpecific<TDistinct>(MSSQLCondition<TSource> conditions, Expression<Func<TSource, TDistinct>> selector)
        {
            using (var context = (DbContext)contextDelegate())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var query = context.Set<TSource>()
                                   .AsQueryable()
                                   .AsNoTracking();

                foreach (var e in conditions.GetIncludes())
                {
                    query = query.Include(e);
                }

                query = query.AsExpandable()
                             .Where(ConditionUtility.GetPredicate(conditions.GetFilters()));

                var result = query.Select(selector.Compile()).FirstOrDefault();


                return result;
            }
        }


        private void DoUpdate(DbContext context,
                              Expression<Func<TSource, object>> expression,
                              TSource tracker,
                              TSource stranger,
                              EntityState state)
        {

            string fieldName = LambdaUtility.GetExpressionBodyName(expression);
            object fieldValue = stranger.GetValueFromProp(fieldName);

            tracker.GetProperties()
                   .ToList()
                   .ForEach(prop =>
                   {

                       if (prop.Name.Equals(fieldName))
                       {

                           //set entity state.
                           SetEntitySatateWhenUpdate(context, tracker, expression, state);

                           ////change value.
                           prop.SetValue(tracker, fieldValue, null);

                       }

                   });

        }


        private void SetEntitySatateWhenUpdate(DbContext context,
                                               TSource tracker,
                                               Expression<Func<TSource, object>> expression,
                                               EntityState state)
        {


            var type = expression.Compile()(tracker)?.GetType();


            if (type == null) return;

            //基本型別或是值型別 , 則判斷更新與否
            if (type.IsPrimitive ||
                type.IsValueType ||
                type == typeof(string))
            {
                context.Entry(tracker).Property(expression).IsModified = state == EntityState.Modified;
                return;
            }

            string name = LambdaUtility.GetExpressionBodyName(expression);
            object fieldValue = tracker.GetValueFromProp(name);
            if (type.IsGenericType) //如果是陣列 , 就迭代內容 並設定ef state
            {


                (fieldValue as IEnumerable<object>).ToList().ForEach(x =>
                {
                    context.Entry(x).State = state;

                });

            }
            else //如果是類別 , 就直接設定ef state
            {

                context.Entry(tracker.GetValueFromProp(name)).State = state;

            }

        }
        private void SetEntitySatateWhenAdd(DbContext context,
                                            TSource tracker,
                                            Expression<Func<TSource, object>> expression,
                                            EntityState state)
        {


            var type = expression.Compile()(tracker)?.GetType();

            //基本型別或是值型別 , 則判斷更新與否
            if (type == null ||
                type.IsPrimitive ||
                type.IsValueType ||
                type == typeof(string))
            {
                return;
            }

            string name = LambdaUtility.GetExpressionBodyName(expression);
            object fieldValue = tracker.GetValueFromProp(name);

            if (type.IsGenericType) //如果是陣列 , 就迭代內容 並設定ef state
            {

                (fieldValue as IEnumerable<object>).ToList().ForEach(x =>
                {
                    context.Entry(x).State = state;

                });

            }
            else //如果是類別 , 就直接設定ef state
            {
                context.Entry(tracker.GetValueFromProp(name)).State = state;

            }

        }

    }
}
