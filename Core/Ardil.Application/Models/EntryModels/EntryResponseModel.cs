using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Application.Models.EntryModels
{
    public class EntryResponseModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public Guid TopicId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
