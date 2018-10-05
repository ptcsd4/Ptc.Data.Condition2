using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Test.Domain
{
    public class Announcement
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string PreviewImagePath { get; set; }
        public string ContentImagePath { get; set; }
        public Nullable<int> TopMost { get; set; }
        public System.DateTime PostStartDate { get; set; }
        public System.DateTime PostEndDate { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string NoticeType { get; set; }
        public string NoticeTarget { get; set; }
        public string CustomizeNoticeUser { get; set; }
        public string removeUserID { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool IsPerformance { get; set; }
        public bool hasPushed { get; set; }
        public bool IsPubilc { get; set; }
        public string DescriptionOfAddress { get; set; }
        public bool DescriptionOfAddressIsURL { get; set; }
        public byte AnnouncementType { get; set; }

        public virtual Coupon Coupon { get; set; }
        public virtual Course Course { get; set; }
        public virtual Lottery Lottery { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<BranchCounter> BranchCounter { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<MachineType> MachineType { get; set; }
    }
}
