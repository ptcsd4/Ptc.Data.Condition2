using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Test.Domain
{
    public class UserCoupon
    {
        public Nullable<System.DateTime> GetDateTime { get; set; }
        public bool Invalid { get; set; }
        public Nullable<System.DateTime> UseDateTime { get; set; }
        public string AccountName { get; set; }
        public int AnnouncementID { get; set; }
        public Nullable<long> CouponSNID { get; set; }

        public virtual Coupon Coupon { get; set; }
        public virtual CouponSN CouponSN { get; set; }
        public virtual User User { get; set; }
    }
}
