using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Test.Domain
{
    public class MachineType
    {
        public string MachineTypeID { get; set; }
        public string BrandID { get; set; }
        public string MachineSerialCodeImagePath { get; set; }
        public string ProductImagePath { get; set; }
        public string BrandName { get; set; }
        public string MachineTypeName { get; set; }
        public string MachineSerialCodeDescription { get; set; }
        public string ShopSuppliesURL { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Announcement> Announcement { get; set; }
    }
}
