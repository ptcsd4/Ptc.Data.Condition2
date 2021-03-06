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
    
    public partial class UserProductWarranty
    {
        public string AccountName { get; set; }
        public string UserWarrantyID { get; set; }
        public string BrandID { get; set; }
        public string MachineTypeID { get; set; }
        public string MachineSerialCode { get; set; }
        public bool HasNoReceipt { get; set; }
        public string NoReceiptReason { get; set; }
        public string ReceiptImagePath { get; set; }
        public string RegisteInfoHistory { get; set; }
        public Nullable<int> SendBackReasonID { get; set; }
        public string SendBackReason { get; set; }
        public Nullable<int> SendBackTimes { get; set; }
        public Nullable<int> ShopChannelID { get; set; }
        public string ShopChannel { get; set; }
        public Nullable<System.DateTime> WarrantyStartDate { get; set; }
        public Nullable<System.DateTime> WarrantyEndDate { get; set; }
        public Nullable<int> WarrantyMonth { get; set; }
        public int ProductWarrantyType { get; set; }
        public int ProductCheckType { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public string QRCodeContent { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<decimal> SaleAmount { get; set; }
        public string CheckUser { get; set; }
    
        public virtual MachineType MachineType { get; set; }
        public virtual SendBackReason SendBackReason1 { get; set; }
        public virtual ShopChannel ShopChannel1 { get; set; }
        public virtual User User { get; set; }
    }
}
