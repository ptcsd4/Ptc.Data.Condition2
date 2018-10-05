using Ptc.Data.Condition2.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Mssql.Operator
{
    public class Allow<T>
    {
        private List<(Expression<Func<T, object>> Expression, Boolean IsModified)> Allows
           = new List<(Expression<Func<T, object>> Expression, Boolean IsModified)>();


        public void Add(Expression<Func<T, object>> Expression, Boolean IsModified) => this.Allows.Add((Expression, IsModified));
        public void Add(string AllowBy, Boolean IsModified)
        {
            if (string.IsNullOrEmpty(AllowBy)) throw new NullReferenceException("[PTC_DATA] ALLOW 並未給入欄位");

            var expression = LambdaUtility.GeneratorExpressionFromPath<T>(AllowBy);

            this.Allows.Add((expression, IsModified));

        }
        public void Clear() => this.Allows.Clear();
        public List<Expression<Func<T, object>>> GetExpressions() => this.Allows.Select(x => x.Expression).ToList();
        public List<(Expression<Func<T, object>> Expression, Boolean IsModified)> GetAll() => this.Allows;

    }
}
