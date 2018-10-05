using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Test.Domain
{
    public class Course
    {

        public int AnnouncementID { get; set; }
        public string Bonus { get; set; }
        public string BrandID { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> SignupEndDate { get; set; }
        public Nullable<System.DateTime> SignupStartDate { get; set; }

        public virtual Announcement Announcement { get; set; }
     
    }
}
