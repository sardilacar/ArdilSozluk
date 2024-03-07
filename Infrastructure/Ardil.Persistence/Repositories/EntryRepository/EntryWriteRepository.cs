using Ardil.Application.Repositories;
using Ardil.Application.Repositories.EntryRepository;
using Ardil.Domain.Entities;
using Ardil.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Persistence.Repositories.EntryRepository
{
    public class EntryWriteRepository : WriteRepository<Entry>, IEntryWriteRepository
    {
        public EntryWriteRepository(ArdilDbContext context) : base(context)
        {
        }
    }
}
