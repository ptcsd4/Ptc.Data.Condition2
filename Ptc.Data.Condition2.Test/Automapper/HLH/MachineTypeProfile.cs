using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ptc.Data.Condition2.DataBase.MSSQL;

namespace Ptc.Data.Condition2.Test.Automapper.HLH
{
    public class MachineTypeProfile : Profile
    {
        public MachineTypeProfile()
        {

            CreateMap<MachineType, Domain.MachineType>()
              .ForMember(dest => dest.MachineTypeID, opt => opt.MapFrom(src => src.MachineTypeID))
              .ForMember(dest => dest.BrandID, opt => opt.MapFrom(src => src.BrandID))
              .ForMember(dest => dest.MachineSerialCodeImagePath, opt => opt.MapFrom(src => src.MachineSerialCodeImagePath))
              .ForMember(dest => dest.ProductImagePath, opt => opt.MapFrom(src => src.ProductImagePath))
              .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.BrandName))
              .ForMember(dest => dest.MachineTypeName, opt => opt.MapFrom(src => src.MachineTypeName))
              .ForMember(dest => dest.MachineSerialCodeDescription, opt => opt.MapFrom(src => src.MachineSerialCodeDescription))
              .ForMember(dest => dest.ShopSuppliesURL, opt => opt.MapFrom(src => src.ShopSuppliesURL))
              .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => src.UpdateDate))
              .ForMember(dest => dest.Announcement, opt => opt.MapFrom(src => src.Announcement))
              .ReverseMap()
              .MaxDepth(3);

        }
    }
}
