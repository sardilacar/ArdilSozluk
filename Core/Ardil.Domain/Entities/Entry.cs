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
    public class Entry: BaseEntity
    {
        
        public string Content { get; set; }
        
        public AppUser User { get; set; }
        
        public Guid UserId { get; set; }
        
        public Topic Topic { get; set; }
        
        public Guid TopicId { get; set; }
        
        public bool Status { get; set; } = false;
    }
}
