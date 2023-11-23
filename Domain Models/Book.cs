using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain_Models.DataSet;

namespace Domain_Models
{
    public class Book:Media
    {
        public string? Author { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public Language Language { get; set; }
        public Genre Genre { get; set; } 
    }
}
