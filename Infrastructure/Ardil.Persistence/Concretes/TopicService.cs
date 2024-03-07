using Ardil.Application.Abstractions;
using Ardil.Application.Repositories.EntryRepository;
using Ardil.Application.Repositories.TopicRepository;
using Ardil.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Persistence.Concretes
{
    public class TopicService : ITopicService
    {
        private readonly ITopicReadRepository _topicReadRepository;
        private readonly IEntryService _entryService;
        private readonly IMapper _mapper;

        public TopicService(ITopicReadRepository topicReadRepository, IEntryService entryService, IMapper mapper)
        {
            _topicReadRepository = topicReadRepository;
            _entryService = entryService;
            _mapper = mapper;
        }

        public async Task<List<Topic>> GetMenuTopics()
        {
            var topicalEntries = await _entryService.GetTopicalEntries();
            topicalEntries.Select(p => p.Topic.Id).ToList();
            throw new NotImplementedException();
        }
    }
}
