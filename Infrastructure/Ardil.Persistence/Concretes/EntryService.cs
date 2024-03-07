using Ardil.Application.Abstractions;
using Ardil.Application.Repositories.EntryRepository;
using Ardil.Domain.Entities;
using Ardil.Application.Models.EntryModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardil.Application.Repositories.TopicRepository;

namespace Ardil.Persistence.Concretes
{
    public class EntryService: IEntryService
    {
        private readonly IEntryReadRepository _entryReadRepository;
        private readonly ITopicReadRepository _topicReadRepository;
        private readonly IMapper _mapper;

        public EntryService(IEntryReadRepository entryReadRepository, IMapper mapper, ITopicReadRepository topicReadRepository)
        {
            _entryReadRepository = entryReadRepository;
            _mapper = mapper;
            _topicReadRepository = topicReadRepository;
        }


        public async Task<List<TopicalEntriesResponseModel>> GetTopicalEntries()
        {
            DateTime today = DateTime.UtcNow;
            DateTime lastWeek = today.AddDays(-7);

            var topicalEntries = await _entryReadRepository
                                    .GetList(e => e.CreatedDate >= lastWeek && e.CreatedDate <= today, false)
                                    .GroupJoin(
                                        _topicReadRepository.GetAll(), 
                                        entry => entry.Topic.Id,
                                        topic => topic.Id,
                                        (entry, topic) => new
                                        {
                                            TopicId = entry.Topic.Id,
                                            EntryCount = topic.Count(),
                                            Entry = entry,
                                            Topic = topic.OrderBy(d => d.CreatedDate).FirstOrDefault()
                                    })
                                    .OrderByDescending(r => r.EntryCount)
                                    .Take(10).ToListAsync();
            List<TopicalEntriesResponseModel> response = new List<TopicalEntriesResponseModel>();
            foreach (var entry in topicalEntries)
            {
                response.Add(new() { Entry = entry.Entry, Topic = entry.Topic, EntryCount = entry.EntryCount });
            }
            return response;
        }

        public async Task<List<EntryResponseModel>> GetEntriesByTopicId(string uuid)
        {
            var entries = await _entryReadRepository
                                    .GetList(e => e.TopicId.Equals(Guid.Parse(uuid)), false).ToListAsync();
            return _mapper.Map<List<EntryResponseModel>>(entries);
        }
    }
}
