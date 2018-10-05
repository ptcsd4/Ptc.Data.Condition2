using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Test.Domain
{
    public class Lottery
    {
        public int AnnouncementID { get; set; }
        public Nullable<System.DateTime> ActiveStartDate { get; set; }
        public Nullable<System.DateTime> ActiveEndDate { get; set; }
        public Nullable<int> LimitPurchase { get; set; }
        public string Precautions { get; set; }

        public virtual Announcement Announcement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BranchCounter> BranchCounter { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShopChannel> ShopChannel { get; set; }
    }
}
