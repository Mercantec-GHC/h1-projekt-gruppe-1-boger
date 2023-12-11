using Domain_Models.Database;

namespace Domain_Models.Webshop.Medias
{
    public class BoardGame : Media, IDatabaseEntry
    {
        public string? Developer { get; set; }
        public int MinPlayerCount { get; set; }
        public int MaxPlayerCount { get; set; }
        public int MinAge { get; set; }
        public int PlayTime { get; set; }

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
