using Ptc.Data.Condition2.Common;
using Ptc.Data.Condition2.Interface.Attribute;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Mssql.Operator
{
    public class Modifier<T>
    {

        private List<(Expression<Func<T, object>> Expression , EntityState EntityState)> Modifies = new List<(Expression<Func<T, object>>, EntityState)>();

        public void Add(Expression<Func<T, object>> Expression, EntityState EntityState) => this.Modifies.Add((Expression, EntityState));
        public void Add(string Modify, EntityState EntityState = EntityState.Modified)
        {
            if (string.IsNullOrEmpty(Modify)) throw new NullReferenceException("[PTC_DATA] Include 並未給入欄位");

            var expression = LambdaUtility.GeneratorExpressionFromPath<T>(Modify);
       
            this.Modifies.Add(((T obj)=> obj.GetValueFromProp(Modify) , EntityState));

        }
        public void Clear() => this.Modifies.Clear();
        public List<Expression<Func<T, object>>> GetExpressions() => this.Modifies.Select(x => x.Expression).ToList();
        public List<(Expression<Func<T, object>>  Expression, EntityState EntityState)> GetAll() => this.Modifies;
    }
}
