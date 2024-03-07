using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Application.DTOs
{
    public class JwtTokenDto
    {
        public Guid Id { get; set; }
        public string AccessToken { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public DateTime Expiration { get; set; }
    }
}
