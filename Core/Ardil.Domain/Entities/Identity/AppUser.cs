using Ardil.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public Guid RoleId { get; set; }
        public AppRole Role { get; set; }
        public List<Entry>? Entries { get; set; }
        public List<Topic>? Topics { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
