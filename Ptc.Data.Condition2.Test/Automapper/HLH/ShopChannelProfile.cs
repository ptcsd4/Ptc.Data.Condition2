using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ptc.Data.Condition2.DataBase.MSSQL;

namespace Ptc.Data.Condition2.Test.Automapper.HLH
{
    public class ShopChannelProfile : Profile
    {
        public ShopChannelProfile()
        {
            CreateMap<ShopChannel , Domain.ShopChannel>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
            .ForMember(dest => dest.ShopChannelName, opt => opt.MapFrom(src => src.ShopChannelName))
            .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.status))
            .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate))
            .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => src.UpdateDate))
            .ForMember(dest => dest.Sorting, opt => opt.MapFrom(src => src.Sorting))
            .ForMember(dest => dest.Lottery, opt => opt.MapFrom(src => src.Lottery))
            .ReverseMap()
            .MaxDepth(3);
        }

    }
}
