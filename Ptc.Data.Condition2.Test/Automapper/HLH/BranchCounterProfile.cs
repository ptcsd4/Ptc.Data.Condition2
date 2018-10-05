using AutoMapper;
using Ptc.Data.Condition2.DataBase.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Test.Automapper.HLH
{
    public class BranchCounterProfile : Profile
    {
        public BranchCounterProfile()
        {


            CreateMap<BranchCounter, Domain.BranchCounter>()
                .ForMember(dest => dest.BranchCounterID, opt => opt.MapFrom(src => src.BranchCounterID))
                .ForMember(dest => dest.BranchCounterName, opt => opt.MapFrom(src => src.BranchCounterName))
                .ForMember(dest => dest.TelephoneArea, opt => opt.MapFrom(src => src.TelephoneArea))
                .ForMember(dest => dest.Telephone, opt => opt.MapFrom(src => src.Telephone))
                .ForMember(dest => dest.IsEnable, opt => opt.MapFrom(src => src.IsEnable))
                .ForMember(dest => dest.AddressCityID, opt => opt.MapFrom(src => src.AddressCityID))
                .ForMember(dest => dest.AddressArea, opt => opt.MapFrom(src => src.AddressArea))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.TradingTime1, opt => opt.MapFrom(src => src.TradingTime1))
                .ForMember(dest => dest.TradingTime2, opt => opt.MapFrom(src => src.TradingTime2))
                .ForMember(dest => dest.TradingTime3, opt => opt.MapFrom(src => src.TradingTime3))
                .ForMember(dest => dest.TransporInfo, opt => opt.MapFrom(src => src.TransporInfo))
                .ForMember(dest => dest.ImgUrl, opt => opt.MapFrom(src => src.ImgUrl))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => src.UpdateDate))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate))
                .ForMember(dest => dest.Announcement, opt => opt.MapFrom(src => src.Announcement))
                .ForMember(dest => dest.Coupon, opt => opt.MapFrom(src => src.Coupon))
                .ForMember(dest => dest.Lottery, opt => opt.MapFrom(src => src.Lottery))
                .ReverseMap()
                .MaxDepth(3);


        }


    }
}
