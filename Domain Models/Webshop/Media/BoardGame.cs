namespace Domain_Models.Webshop.Media
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
