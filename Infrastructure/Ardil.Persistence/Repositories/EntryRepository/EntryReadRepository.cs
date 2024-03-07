using System;
using Ardil.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardil.Application.Repositories.EntryRepository;
using Ardil.Persistence.Contexts;

namespace Ardil.Persistence.Repositories.EntryRepository
{
    public class EntryReadRepository : ReadRepository<Entry>, IEntryReadRepository
    {
        public EntryReadRepository(ArdilDbContext context) : base(context)
        {
        }
    }
}
