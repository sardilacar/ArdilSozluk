using Ardil.Application.DTOs;
using Ardil.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Application.Abstractions.Jwt
{
    public interface ITokenHandler
    {
        public JwtTokenDto CreateAccessToken(int minute, AppUser user, List<string> userRoles);

        public bool ValidateToken(JwtTokenDto token);
    }
}
