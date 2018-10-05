using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Test.Domain
{
    public class User
    {
        public string AccountName { get; set; }
        public string PhoneVaildCode { get; set; }
        public Nullable<System.DateTime> PhoneVaildCodeDate { get; set; }
        public int DailyPhoneVaildCount { get; set; }
        public string ResetPasswordCode { get; set; }
        public Nullable<System.DateTime> ResetPasswordDate { get; set; }
        public int DailyResetPasswordCodeCount { get; set; }
        public string RegistrationID { get; set; }
        public Nullable<bool> IsVaildPhone { get; set; }
        public string UserInfoVersion { get; set; }
        public Nullable<int> ResetPasswordCount { get; set; }
        public Nullable<int> PhoneVaildCount { get; set; }
        public Nullable<int> MobileDevice { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCoupon> UserCoupon { get; set; }
      
    }
}
