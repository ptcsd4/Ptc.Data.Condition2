using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Interface.Abstract
{
    public interface ICondition<TSource> : ICondition where TSource : class 
    {
    }
}
