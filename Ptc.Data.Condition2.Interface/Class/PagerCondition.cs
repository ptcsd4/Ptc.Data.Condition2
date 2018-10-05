using Ptc.Data.Condition2.Interface.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Interface.Class
{ 
    public abstract class PagerCondition : ICondition
    {
        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int TotalCount { get; set; }
  
    }
}
