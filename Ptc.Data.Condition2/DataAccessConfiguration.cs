using Ptc.Data.Condition2.Interface.Common;
using Ptc.Data.Condition2.Interface.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2
{
    public static class DataAccessConfiguration
    {

        private static Dictionary<DBStructureType, ISetup> SetupDictionary = new Dictionary<DBStructureType, ISetup>();

        public static void Configure(ISetup setup) => SetupDictionary.Add(setup.Type, setup);

        public static void Configure(params ISetup[] setups) {

            setups?.ToList().ForEach(setup =>
            {
                SetupDictionary.Add(setup.Type, setup);
            });
        }


        public static Boolean HasConfig(DBStructureType type) => SetupDictionary.ContainsKey(type);

        public static ISetup GetConfig(DBStructureType type)
        {
            SetupDictionary.TryGetValue(type, out ISetup setup);

            return setup;
        }
        
    }
}
