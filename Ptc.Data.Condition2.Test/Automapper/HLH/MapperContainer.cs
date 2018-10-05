using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ptc.Data.Condition2.DataBase.MSSQL;

namespace Ptc.Data.Condition2.Test.Automapper.HLH
{
    public static class MapperContainer
    {
        public static IMapper Mapper = null;

        public static TDestination Map<TDestination>(object data)
        {
            try
            {
                if (Mapper == null)
                    throw new NullReferenceException("[Automapper] Instance is null");

                return Mapper.Map<TDestination>(data);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static void SetConfig(MapperConfiguration config)
        {
            Mapper = config.CreateMapper();
        }

    }
}
