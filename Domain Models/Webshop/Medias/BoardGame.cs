namespace Domain_Models.Webshop.Medias
{
    public class BoardGame : Media
    {
        public string? Developer { get; set; }
        public int MinPlayerCount { get; set; }
        public int MaxPlayerCount { get; set; }
        public int MinAge { get; set; }
        public int PlayTime { get; set; }

    }
}
