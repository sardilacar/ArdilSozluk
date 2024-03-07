using Ardil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Application.Models.EntryModels
{
    public class TopicalEntriesResponseModel
    {
        public Topic Topic { get; set; }
        public int EntryCount { get; set; }
        public Entry Entry { get; set; }
    }
}
