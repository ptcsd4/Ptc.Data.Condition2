using AutoMapper;
using Ptc.Data.Condition2.DataBase.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Data.Condition2.Test.Automapper.HLH
{
    public class AnnouncementProfile : Profile
    {

        public  AnnouncementProfile()
        {
            CreateMap<Announcement, Domain.Announcement>()
                 .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                 .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                 .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                 .ForMember(dest => dest.PreviewImagePath, opt => opt.MapFrom(src => src.PreviewImagePath))
                 .ForMember(dest => dest.ContentImagePath, opt => opt.MapFrom(src => src.ContentImagePath))
                 .ForMember(dest => dest.TopMost, opt => opt.MapFrom(src => src.TopMost))
                 .ForMember(dest => dest.PostStartDate, opt => opt.MapFrom(src => src.PostStartDate))
                 .ForMember(dest => dest.PostEndDate, opt => opt.MapFrom(src => src.PostEndDate))
                 .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate))
                 .ForMember(dest => dest.NoticeType, opt => opt.MapFrom(src => src.NoticeType))
                 .ForMember(dest => dest.NoticeTarget, opt => opt.MapFrom(src => src.NoticeTarget))
                 .ForMember(dest => dest.CustomizeNoticeUser, opt => opt.MapFrom(src => src.CustomizeNoticeUser))
                 .ForMember(dest => dest.removeUserID, opt => opt.MapFrom(src => src.removeUserID))
                 .ForMember(dest => dest.IsPerformance, opt => opt.MapFrom(src => src.IsPerformance))
                 .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => src.UpdateDate))
                 .ForMember(dest => dest.hasPushed, opt => opt.MapFrom(src => src.hasPushed))
                 .ForMember(dest => dest.IsPubilc, opt => opt.MapFrom(src => src.IsPubilc))
                 .ForMember(dest => dest.DescriptionOfAddress, opt => opt.MapFrom(src => src.DescriptionOfAddress))
                 .ForMember(dest => dest.DescriptionOfAddressIsURL, opt => opt.MapFrom(src => src.DescriptionOfAddressIsURL))
                 .ForMember(dest => dest.AnnouncementType, opt => opt.MapFrom(src => src.AnnouncementType))
                 .ForMember(dest => dest.Coupon, opt => opt.MapFrom(src => src.Coupon))
                 .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.Course))
                 .ForMember(dest => dest.Lottery, opt => opt.MapFrom(src => src.Lottery))
                 .ForMember(dest => dest.BranchCounter, opt => opt.MapFrom(src => src.BranchCounter))
                 .ForMember(dest => dest.MachineType, opt => opt.MapFrom(src => src.MachineType))
                 .ReverseMap()
                 .MaxDepth(3);

        }
    }
}
