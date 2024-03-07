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
    internal class AppUserReadRepository : ReadRepository<AppUser>, IAppUserReadRepository
    {
        public AppUserReadRepository(ArdilDbContext context) : base(context)
        {
        }
    }
}
