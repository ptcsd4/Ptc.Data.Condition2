using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Interface.Attribute
{

    public class BehaviorAttribute : System.Attribute , IFilterAtrribute
    {
        public object DynamicInstance { get; private set; }

        public BehaviorAttribute(System.Type Type, params object[] ConstructorArguments)
        {
            DynamicInstance =
                Activator.CreateInstance(Type, ConstructorArguments);
        }

    }
}
