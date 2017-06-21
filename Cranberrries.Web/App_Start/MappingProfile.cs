using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapper.Configuration;
using Cranberrries.Web.Dtos;
using Cranberrries.Web.Models;

namespace Cranberrries.Web.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Song, SongDto>()
                .ForMember(t=>t.Album,o=>o.MapFrom(q=>Mapper.Map<Album,AlbumDto>(q.Album)));

            CreateMap<SongDto, Song>()
                .ForMember(t => t.Id, opt => opt.Ignore());
                //.ForMember(t => t.Album, o => o.MapFrom(q => Mapper.Map<AlbumDto, Album>(q.Album)));

            CreateMap<AlbumDto, Album>()
                .ForMember(t=>t.Id,opt=>opt.Ignore());

            CreateMap<Album, AlbumDto>();

            



        }
    }
}