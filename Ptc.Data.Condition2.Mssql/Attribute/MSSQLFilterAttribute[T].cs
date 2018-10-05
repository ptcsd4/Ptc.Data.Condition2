using Ptc.Data.Condition2.Interface.Attribute;
using Ptc.Data.Condition2.Interface.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Mssql.Attribute
{
    /// <summary>
    ///  [BehaviorAttribute(typeof(Attribute.MSSQLFilterAttribute<string>) , 1)]
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MSSQLFilterAttribute<T> : IMSSQLFilterAtrribute
    {
        public MSSQLFilterAttribute(Expression<Func<T, object>> Expression, 
                                    ExpressionType ExpressionType,
                                    PredicateType PredicateType)
        {
            this.Expression = Expression;
            this.ExpressionType = ExpressionType;
            this.PredicateType = PredicateType;
        }

        public Expression<Func<T, object>> Expression { get; set; }
        public object Value { get; set; }
        public ExpressionType ExpressionType { get; set; }
        public PredicateType PredicateType { get; set; }
    }
}
