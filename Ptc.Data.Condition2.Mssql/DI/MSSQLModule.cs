using Autofac;
using Ptc.Data.Condition2.Mssql.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Mssql.DI
{

    public class MSSQLModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

         
            var asm = typeof(MSSQLModule).Assembly;

            builder.RegisterAssemblyTypes(asm).AsImplementedInterfaces().SingleInstance();

            builder.RegisterGeneric(typeof(MSSQLRepository<>))
                 .AsSelf()
                 .As(typeof(IMSSQLRepository<>))
                 .InstancePerDependency();

            builder.RegisterGeneric(typeof(MSSQLRepository<,>))
                  .AsSelf()
                  .As(typeof(IMSSQLRepository<,>))
                  .InstancePerDependency();


        }
    }
}
