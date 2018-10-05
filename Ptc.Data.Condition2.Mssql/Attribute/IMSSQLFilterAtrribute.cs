using Ptc.Data.Condition2.Interface.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Mssql.Attribute
{
    public interface IMSSQLFilterAtrribute
    {
        object Value { get; set; }

        ExpressionType ExpressionType { get; set; }

        PredicateType PredicateType { get; set; }
    }
}
