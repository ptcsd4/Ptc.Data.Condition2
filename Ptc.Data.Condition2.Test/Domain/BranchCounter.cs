using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Test.Domain
{
    public class BranchCounter
    {
        public int BranchCounterID { get; set; }
        public string BranchCounterName { get; set; }
        public string TelephoneArea { get; set; }
        public string Telephone { get; set; }
        public bool IsEnable { get; set; }
        public int AddressCityID { get; set; }
        public string AddressArea { get; set; }
        public string Address { get; set; }
        public string TradingTime1 { get; set; }
        public string TradingTime2 { get; set; }
        public string TradingTime3 { get; set; }
        public string TransporInfo { get; set; }
        public string ImgUrl { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }

        public virtual ICollection<Announcement> Announcement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Coupon> Coupon { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lottery> Lottery { get; set; }
    }
}
