using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Test.Domain
{
    public class Coupon
    {

        public Nullable<int> CouponCount { get; set; }
        public int CurrentCount { get; set; }
        public Nullable<int> DiscountAmount { get; set; }
        public Nullable<decimal> DiscountPercentage { get; set; }
        public System.DateTime ExchangeStartDate { get; set; }
        public System.DateTime ExchangeEndDate { get; set; }
        public Nullable<int> LimitAmountOfPurchase { get; set; }
        public string LimitOther { get; set; }
        public int AnnouncementID { get; set; }
        public Nullable<System.DateTime> ActiveStartDate { get; set; }
        public Nullable<System.DateTime> ActiveEndDate { get; set; }
        public string DescriptionOfUse { get; set; }
        public string DescriptionOfOther { get; set; }

        public virtual Announcement Announcement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CouponSN> CouponSN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCoupon> UserCoupon { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BranchCounter> BranchCounter { get; set; }
    }
}
