using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ptc.Data.Condition2.DataBase.MSSQL;

namespace Ptc.Data.Condition2.Test.Automapper.HLH
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, Domain.Course>()
           .ForMember(dest => dest.AnnouncementID, opt => opt.MapFrom(src => src.AnnouncementID))
           .ForMember(dest => dest.Bonus, opt => opt.MapFrom(src => src.Bonus))
           .ForMember(dest => dest.BrandID, opt => opt.MapFrom(src => src.BrandID))
           .ForMember(dest => dest.Remark, opt => opt.MapFrom(src => src.Remark))
           .ForMember(dest => dest.SignupEndDate, opt => opt.MapFrom(src => src.SignupEndDate))
           .ForMember(dest => dest.SignupStartDate, opt => opt.MapFrom(src => src.SignupStartDate))
           .ForMember(dest => dest.Announcement, opt => opt.MapFrom(src => src.Announcement))
           .ReverseMap()
           .MaxDepth(3);
        }
    }
}
