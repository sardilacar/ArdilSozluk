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
    internal class TopicReadRepository : ReadRepository<Topic>, ITopicReadRepository
    {
        public TopicReadRepository(ArdilDbContext context) : base(context)
        {
        }
    }
}
