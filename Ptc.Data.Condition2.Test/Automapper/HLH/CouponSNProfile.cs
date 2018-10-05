using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ptc.Data.Condition2.DataBase.MSSQL;

namespace Ptc.Data.Condition2.Test.Automapper.HLH
{

    public class CouponSNProfile : Profile
    {

        public CouponSNProfile()
        {
            CreateMap<CouponSN, Domain.CouponSN>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
            .ForMember(dest => dest.SerialCode, opt => opt.MapFrom(src => src.SerialCode))
            .ForMember(dest => dest.IsValid, opt => opt.MapFrom(src => src.IsValid))
            .ForMember(dest => dest.AnnouncementID, opt => opt.MapFrom(src => src.AnnouncementID))
            .ForMember(dest => dest.Coupon, opt => opt.MapFrom(src => src.Coupon))
            .ForMember(dest => dest.UserCoupon, opt => opt.MapFrom(src => src.UserCoupon))
            .ReverseMap()
            .MaxDepth(3);
        }

    }
}
