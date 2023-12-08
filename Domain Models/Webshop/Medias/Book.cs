using Domain_Models.Database;

namespace Domain_Models.Webshop.Medias
{
    public class Book : Media
    {
        public string? Author { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public DataSet.Language Language { get; set; }
        public DataSet.Genre Genre { get; set; }

        public override void AddDBEntry()
        {
            throw new NotImplementedException();
        }

        public override IDatabaseEntry GetDBEntry(int pKey)
        {
            throw new NotImplementedException();
        }

        public override void RemoveDBEntry()
        {
            throw new NotImplementedException();
        }

        public override bool UpdateDBEntry()
        {
            throw new NotImplementedException();
        }
    }
}
