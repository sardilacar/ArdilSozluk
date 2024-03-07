using Ardil.Application.Repositories.IdentityRepository.AppRoleRepository;
using Ardil.Domain.Entities.Identity;
using Ardil.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Persistence.Repositories.IdentityRepository.AppRoleRepository
{
    public class AppRoleReadRepository : ReadRepository<AppRole>, IAppRoleReadRepository
    {
        public AppRoleReadRepository(ArdilDbContext context) : base(context)
        {
        }
    }
}
