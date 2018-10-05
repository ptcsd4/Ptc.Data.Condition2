using LinqKit;
using Ptc.Data.Condition2.Common;
using Ptc.Data.Condition2.Interface.Attribute;
using Ptc.Data.Condition2.Interface.Type;
using Ptc.Data.Condition2.Mssql.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Mssql.Utility
{
    public static class ConditionUtility
    {
        public static IEnumerable<IMSSQLFilterAtrribute> GetFilters(this object Data)
        {
            List<IMSSQLFilterAtrribute> filters = new List<IMSSQLFilterAtrribute>();

            IEnumerable<PropertyInfo> properties = Data.GetType()
                                                       .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                                       .AsEnumerable();

            properties.ToList()
                      .ForEach(prop =>
            {

                var value = Data.GetValueFromProp(prop.Name);

                if (FilterGuard(prop, value) == false) return;

                var mssqlFilter = prop.GetCustomAttribute(typeof(MSSQLFilterAttribute), true) as MSSQLFilterAttribute;

                if (mssqlFilter != null)
                {

                    mssqlFilter.Value = value;
                    filters.Add(mssqlFilter);
                }

                var bahaviorFilter = prop.GetCustomAttribute(typeof(BehaviorAttribute), true) as BehaviorAttribute;

                if (bahaviorFilter != null && bahaviorFilter.DynamicInstance.GetType() == typeof(MSSQLFilterAttribute<>))
                {
                    var filter = (IMSSQLFilterAtrribute)bahaviorFilter.DynamicInstance;
                    filter.Value = value;
                    filters.Add(filter);
                }

            });

            return filters;
        }

        public static ExpressionStarter<T> GetPredicate<T>(List<(Expression<Func<T, bool>> Expression, PredicateType PredicateType)> Filters)
        {
            ExpressionStarter<T> linqkitFilter = PredicateBuilder.New<T>(true);


            Filters?.ForEach(x =>
            {
                switch (x.PredicateType)
                {
                    case PredicateType.And:
                        linqkitFilter = linqkitFilter.And(x.Expression);
                        break;
                    case PredicateType.Or:
                        linqkitFilter = linqkitFilter.Or(x.Expression);
                        break;
                }
            });

            return linqkitFilter;
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> Source, Expression<Func<T, object>> Expression, OrderType OrderType)
        {

            if (Expression == null) return Source;

            var methodName = OrderType == OrderType.Asc ? "OrderBy" : "OrderByDescending";

            var callExp = CallExpression(Source, Expression, methodName);
            
            return Source.Provider.CreateQuery<T>(callExp);
        }

        public static IQueryable<T> ThenBy<T>(this IQueryable<T> Source, Expression<Func<T, object>> Expression, OrderType OrderType)
        {
            if (Expression == null) return Source;

            var methodName = OrderType == OrderType.Asc ? "ThenBy" : "ThenByDescending";

            var callExp = CallExpression(Source, Expression, methodName);

            return Source.Provider.CreateQuery<T>(callExp);
        }

        private static MethodCallExpression CallExpression<T>(IQueryable<T> Source , Expression<Func<T, object>> Expression, string MehodName)
        {
            var typeArguments = new Type[] { typeof(T), LambdaUtility.GetExpressionBodyType(Expression) };

            var orderByExp = System.Linq.Expressions.Expression.Lambda(
                System.Linq.Expressions.Expression.PropertyOrField(Expression.Parameters[0],
                LambdaUtility.GetExpressionBodyName<T, object>(Expression)),
                Expression.Parameters[0]);


            var resultExp = System.Linq.Expressions.Expression.Call(
                typeof(Queryable),
                MehodName,
                typeArguments,
                Source.Expression,
                orderByExp);

            return resultExp;

        }


        private static bool FilterGuard(PropertyInfo Property, object Value)
        {

            if (Value == null) return false;

            if (Value is string && string.IsNullOrEmpty((string)Value)) return false;


            return true;
        }

    }
}
