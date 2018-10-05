using AutoMapper;
using Ptc.Data.Condition2.Interface.Common;
using Ptc.Data.Condition2.Interface.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Mssql.Common
{
    public class MSSQLDataSetting : ISetup
    {

        /// <summary>
        /// 結構註記
        /// </summary>
        public DBStructureType Type { get; set; } = DBStructureType.MSSQL;

        /// <summary>
        ///  設定DBContext
        ///  ※ 支援抽換 IDisposable
        /// </summary>
        /// <param name="func"></param>
        public Func<IDisposable> DefaultDBContextDelegate { get; set; }

        /// <summary>
        /// 設定Automapper
        /// ※ 支援抽換 IMapper
        /// </summary>
        /// <param name="func"></param>
        public Func<IMapper> DefaultMappingConfig { get; set; }



    }
}
