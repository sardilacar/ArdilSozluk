using Ardil.Domain.Entities;
using Ardil.Application.Models.EntryModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Application.Helper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Entry, EntryResponseModel>().ReverseMap();
            CreateMap<Entry, TopicalEntriesResponseModel>().ReverseMap();
        }
    }
}
