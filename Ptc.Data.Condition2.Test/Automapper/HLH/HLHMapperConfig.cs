using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ptc.Data.Condition2.Test.Automapper.HLH
{
    public static class HLHMapperConfig
    {


        public static MapperConfiguration HLH = new MapperConfiguration(x =>
        {
            x.AddProfile<AnnouncementProfile>();
            x.AddProfile<BranchCounterProfile>();
            x.AddProfile<CouponProfile>();
            x.AddProfile<CourseProfile>();
            x.AddProfile<LotteryProfile>();
            x.AddProfile<MachineTypeProfile>();
            x.AddProfile<ShopChannelProfile>();
            x.AddProfile<UserCouponProfile>();
            x.AddProfile<UserProfile>();
        });

    }
}
