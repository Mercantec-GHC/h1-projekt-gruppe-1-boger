using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Models
{
    public class BoardGame:Media
    {
        public string? Developer { get; set; }
        public string? PlayerCount { get; set; }
        public string? Age { get; set; }
        public int PlayTime { get; set; }

    }
}
