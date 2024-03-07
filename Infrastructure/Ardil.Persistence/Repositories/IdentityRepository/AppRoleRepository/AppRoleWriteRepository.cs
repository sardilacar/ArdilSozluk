using Ardil.Application.Repositories;
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
    internal class AppRoleWriteRepository : WriteRepository<AppRole>, IAppRoleWriteRepository
    {
        public AppRoleWriteRepository(ArdilDbContext context) : base(context)
        {
        }
    }
}
