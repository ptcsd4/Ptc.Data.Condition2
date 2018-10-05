using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ptc.Data.Condition2.DataBase.MSSQL;

namespace Ptc.Data.Condition2.Test.Automapper.HLH
{
    public class LotteryProfile : Profile
    {
        public LotteryProfile()
        {
            CreateMap<Lottery, Domain.Lottery>()
             .ForMember(dest => dest.AnnouncementID, opt => opt.MapFrom(src => src.AnnouncementID))
             .ForMember(dest => dest.ActiveStartDate, opt => opt.MapFrom(src => src.ActiveStartDate))
             .ForMember(dest => dest.ActiveEndDate, opt => opt.MapFrom(src => src.ActiveEndDate))
             .ForMember(dest => dest.LimitPurchase, opt => opt.MapFrom(src => src.LimitPurchase))
             .ForMember(dest => dest.Precautions, opt => opt.MapFrom(src => src.Precautions))
             .ForMember(dest => dest.Announcement, opt => opt.MapFrom(src => src.Announcement))
             .ForMember(dest => dest.BranchCounter, opt => opt.MapFrom(src => src.BranchCounter))
             .ForMember(dest => dest.ShopChannel, opt => opt.MapFrom(src => src.ShopChannel))
             .ReverseMap()
             .MaxDepth(3);
        }
    }
}
