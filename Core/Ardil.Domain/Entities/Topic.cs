using Ardil.Domain.Entities.Common;
using Ardil.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Domain.Entities
{
    public class Topic: BaseEntity
    {
        public  string Subject { get; set; }
        public  AppUser User { get; set; }
        public  Guid UserId { get; set; }
        public List<Entry>? Entries { get; set; }
    }
}
