using Ardil.Domain.Entities;
using Ardil.Application.Models.EntryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Application.Abstractions
{
    public interface IEntryService
    {
        public Task<List<EntryResponseModel>> GetEntriesByTopicId(string uuid);
        public Task<List<TopicalEntriesResponseModel>> GetTopicalEntries();
    }
}
