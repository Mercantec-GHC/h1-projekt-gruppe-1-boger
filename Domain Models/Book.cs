using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public DateTime Release { get; set; }
        public int Pages { get; set; }
        
        //public Genre Genre { get; set; } ||waiting for enum||
    }
}
