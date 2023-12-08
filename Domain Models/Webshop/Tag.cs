using Domain_Models.Database;

namespace Domain_Models.Webshop
{
    public class Tag : IDatabaseEntry
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public void AddDBEntry()
        {
            throw new NotImplementedException();
        }

        public IDatabaseEntry GetDBEntry(int pKey)
        {
            throw new NotImplementedException();
        }

        public void RemoveDBEntry()
        {
            throw new NotImplementedException();
        }

        public bool UpdateDBEntry()
        {
            throw new NotImplementedException();
        }
    }
}