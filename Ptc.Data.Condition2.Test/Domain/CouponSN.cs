using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Test.Domain
{
    public class CouponSN
    {

        public long ID { get; set; }
        public string SerialCode { get; set; }
        public bool IsValid { get; set; }
        public int AnnouncementID { get; set; }

        public virtual Coupon Coupon { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCoupon> UserCoupon { get; set; }
    }
}
