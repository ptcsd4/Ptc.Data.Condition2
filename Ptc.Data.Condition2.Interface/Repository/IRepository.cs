using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Interface.Repository
{
    public interface IRepository
    {

        void OverrideDBContext(Func<IDisposable> func);
        
    }
}
