using Ptc.Data.Condition2.Common;
using Ptc.Data.Condition2.Interface.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Mssql.Operator
{
    public class Filter<T>
    {

        private List<(Expression<Func<T, bool>> Expression, PredicateType PredicateType)> Filters
            = new List<(Expression<Func<T, bool>> Expression, PredicateType PredicateType)>();

        public void Add(Expression<Func<T, bool>> Expression, PredicateType PredicateType) => this.Filters.Add((Expression, PredicateType));
        public void Add(string FilterBy, object Value, ExpressionType ExpressionType, PredicateType PredicateType)
        {
            if (string.IsNullOrEmpty(FilterBy)) throw new NullReferenceException("[PTC_DATA] FILTER 並未給入欄位");

            var expression = LambdaUtility.GeneratorExpression<T>(FilterBy, Value, ExpressionType);

            this.Filters.Add((expression, PredicateType));

        }
        public void Clear() => this.Filters.Clear();
        public List<Expression<Func<T, bool>>> GetExpressions() => this.Filters.Select(x => x.Expression).ToList();
        public List<(Expression<Func<T, bool>> Expression, PredicateType PredicateType)> GetAll() => this.Filters;
    }
}
