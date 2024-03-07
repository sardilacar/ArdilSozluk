using Ardil.Application.Repositories.IdentityRepository.AppUserRepository;
using Ardil.Domain.Entities.Identity;
using Ardil.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Persistence.Repositories.IdentityRepository.AppUserRepository
{
    internal class AppUserWriteRepository : WriteRepository<AppUser>, IAppUserWriteRepository
    {
        public AppUserWriteRepository(ArdilDbContext context) : base(context)
        {
        }
    }
}
