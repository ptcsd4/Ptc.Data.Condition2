//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ptc.Data.Condition2.DataBase.MSSQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class StopMachine
    {
        public int ID { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int StopRangeType { get; set; }
        public string ViewContent { get; set; }
        public bool isExec { get; set; }
        public System.DateTime LastUpdateTime { get; set; }
        public string LastUpdateUserName { get; set; }
        public System.DateTime CreateUpdateTime { get; set; }
        public string CreateUpdateUserName { get; set; }
    }
}