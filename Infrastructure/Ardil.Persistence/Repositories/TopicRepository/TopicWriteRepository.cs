using Ardil.Application.Repositories.TopicRepository;
using Ardil.Domain.Entities;
using Ardil.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Persistence.Repositories.TopicRepository
{
    internal class TopicWriteRepository : WriteRepository<Topic>, ITopicWriteRepository
    {
        public TopicWriteRepository(ArdilDbContext context) : base(context)
        {
        }
    }
}
