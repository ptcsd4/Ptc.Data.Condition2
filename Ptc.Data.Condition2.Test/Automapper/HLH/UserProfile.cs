using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ptc.Data.Condition2.DataBase.MSSQL;

namespace Ptc.Data.Condition2.Test.Automapper.HLH
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<User, Domain.User>()
            .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.AccountName))
            .ForMember(dest => dest.PhoneVaildCode, opt => opt.MapFrom(src => src.PhoneVaildCode))
            .ForMember(dest => dest.PhoneVaildCodeDate, opt => opt.MapFrom(src => src.PhoneVaildCodeDate))
            .ForMember(dest => dest.DailyPhoneVaildCount, opt => opt.MapFrom(src => src.DailyPhoneVaildCount))
            .ForMember(dest => dest.ResetPasswordCount, opt => opt.MapFrom(src => src.ResetPasswordCode))
            .ForMember(dest => dest.ResetPasswordDate, opt => opt.MapFrom(src => src.ResetPasswordDate))
            .ForMember(dest => dest.DailyResetPasswordCodeCount, opt => opt.MapFrom(src => src.DailyResetPasswordCodeCount))
            .ForMember(dest => dest.RegistrationID, opt => opt.MapFrom(src => src.RegistrationID))
            .ForMember(dest => dest.IsVaildPhone, opt => opt.MapFrom(src => src.IsVaildPhone))
            .ForMember(dest => dest.ResetPasswordCount, opt => opt.MapFrom(src => src.ResetPasswordCount))
            .ForMember(dest => dest.PhoneVaildCode, opt => opt.MapFrom(src => src.PhoneVaildCode))
            .ForMember(dest => dest.MobileDevice, opt => opt.MapFrom(src => src.MobileDevice))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
            .ForMember(dest => dest.UserCoupon, opt => opt.MapFrom(src => src.UserCoupon))
            .ReverseMap()
            .MaxDepth(3);
        }
    }
}
