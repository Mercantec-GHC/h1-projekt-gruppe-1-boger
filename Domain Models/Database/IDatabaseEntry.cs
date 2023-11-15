using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Models.Database
{
    public interface IDatabaseEntry
    {
        public IDatabaseEntry GetDBEntry(int pKey);
        public void AddDBEntry();
        public void RemoveDBEntry();
        public bool UpdateDBEntry();
    }
}
