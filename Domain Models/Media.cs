using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Models
{
   public class Media
    {
        public int Id { get; set; }
        public string? Titel { get; set; }
      
        // public Language Language { get; set; } ||waiting for enum||
        public List<Tag>? Tags { get; set; }
    }
}
