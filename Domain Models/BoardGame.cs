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
        public int MinPlayerCount { get; set; }
        public int MaxPlayerCount { get; set; }
        public int MinAge { get; set; }
        public int PlayTime { get; set; }

    }
}
