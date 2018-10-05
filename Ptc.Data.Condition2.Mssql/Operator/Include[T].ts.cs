using Ptc.Data.Condition2.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Mssql.Operator
{
    public class Include<T>
    {
        private List<Expression<Func<T, object>>> Includes = new List<Expression<Func<T, object>>>();

        public void Add(Expression<Func<T, object>> Expression) => this.Includes.Add(Expression);
        public void Add(string IncludeBy)
        {
            if (string.IsNullOrEmpty(IncludeBy)) throw new NullReferenceException("[PTC_DATA] Include 並未給入欄位");

            var expression = LambdaUtility.GeneratorExpressionFromPath<T>(IncludeBy);

            this.Includes.Add(expression);

        }
        public void Clear()  => this.Includes.Clear();
        public List<Expression<Func<T, object>>> GetExpressions() => this.Includes.ToList();
        public List<Expression<Func<T, object>>> GetAll() => this.Includes;
    }
}
