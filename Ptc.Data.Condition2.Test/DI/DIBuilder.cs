using Autofac;
using Ptc.Data.Condition2.Mssql.DI;
using Ptc.Data.Condition2.Mssql.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Test.DI
{
    public static class DIBuilder
    {

        public static IContainer container;

        public static T GetObject<T>()
        {
           
            var builder = new ContainerBuilder();

            builder.RegisterModule(new MSSQLModule());
      
            container = builder.Build();
            
            return container.Resolve<T>();
        }


    }
}
