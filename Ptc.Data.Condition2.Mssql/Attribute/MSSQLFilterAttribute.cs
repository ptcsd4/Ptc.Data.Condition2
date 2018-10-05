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

    [AttributeUsage((AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property))]
    public class MSSQLFilterAttribute : System.Attribute, IMSSQLFilterAtrribute
    {
        public MSSQLFilterAttribute(string Target , ExpressionType ExpressionType , PredicateType PredicateType)
        {
            this.Target = Target;
            this.ExpressionType = ExpressionType;
            this.PredicateType = PredicateType;
        }

        public string Target { get; set; }
        public object Value { get; set; }
        public ExpressionType ExpressionType { get; set; }
        public PredicateType PredicateType { get; set; }
    }
}