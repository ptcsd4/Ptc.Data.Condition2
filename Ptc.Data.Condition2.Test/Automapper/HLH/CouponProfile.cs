using AutoMapper;
using System;
using Ptc.Data.Condition2.DataBase.MSSQL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Test.Automapper.HLH
{
    public class CouponProfile : Profile
    {
        public CouponProfile()
        {

            CreateMap<Coupon, Domain.Coupon>()
                .ForMember(dest => dest.CouponCount, opt => opt.MapFrom(src => src.CouponCount))
                .ForMember(dest => dest.CurrentCount, opt => opt.MapFrom(src => src.CurrentCount))
                .ForMember(dest => dest.DiscountAmount, opt => opt.MapFrom(src => src.DiscountAmount))
                .ForMember(dest => dest.DiscountPercentage, opt => opt.MapFrom(src => src.DiscountPercentage))
                .ForMember(dest => dest.ExchangeStartDate, opt => opt.MapFrom(src => src.ExchangeStartDate))
                .ForMember(dest => dest.LimitAmountOfPurchase, opt => opt.MapFrom(src => src.LimitAmountOfPurchase))
                .ForMember(dest => dest.LimitOther, opt => opt.MapFrom(src => src.LimitOther))
                .ForMember(dest => dest.AnnouncementID, opt => opt.MapFrom(src => src.AnnouncementID))
                .ForMember(dest => dest.ActiveStartDate, opt => opt.MapFrom(src => src.ActiveStartDate))
                .ForMember(dest => dest.ActiveEndDate, opt => opt.MapFrom(src => src.ActiveEndDate))
                .ForMember(dest => dest.DescriptionOfUse, opt => opt.MapFrom(src => src.DescriptionOfUse))
                .ForMember(dest => dest.DescriptionOfOther, opt => opt.MapFrom(src => src.DescriptionOfOther))
                .ForMember(dest => dest.Announcement, opt => opt.MapFrom(src => src.Announcement))
                .ForMember(dest => dest.CouponSN, opt => opt.MapFrom(src => src.CouponSN))
                .ForMember(dest => dest.UserCoupon, opt => opt.MapFrom(src => src.UserCoupon))
                .ForMember(dest => dest.BranchCounter, opt => opt.MapFrom(src => src.BranchCounter))
                .ReverseMap()
                .MaxDepth(3);
        }




    }
}
