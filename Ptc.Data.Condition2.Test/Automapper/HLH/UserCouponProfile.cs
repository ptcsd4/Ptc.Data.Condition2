using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ptc.Data.Condition2.DataBase.MSSQL;

namespace Ptc.Data.Condition2.Test.Automapper.HLH
{
    public class UserCouponProfile : Profile
    {

        public UserCouponProfile()
        {
            CreateMap<UserCoupon, Domain.UserCoupon>()
            .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.AccountName))
            .ForMember(dest => dest.AnnouncementID, opt => opt.MapFrom(src => src.AnnouncementID))
            .ForMember(dest => dest.Coupon, opt => opt.MapFrom(src => src.Coupon))
            .ForMember(dest => dest.CouponSN, opt => opt.MapFrom(src => src.CouponSN))
            .ForMember(dest => dest.CouponSNID, opt => opt.MapFrom(src => src.CouponSNID))
            .ForMember(dest => dest.GetDateTime, opt => opt.MapFrom(src => src.GetDateTime))
            .ForMember(dest => dest.Invalid, opt => opt.MapFrom(src => src.Invalid))
            .ForMember(dest => dest.UseDateTime, opt => opt.MapFrom(src => src.UseDateTime))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))        
            .ReverseMap()
            .MaxDepth(3);
        }
    }
}
