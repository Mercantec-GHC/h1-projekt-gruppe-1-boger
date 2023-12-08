namespace Domain_Models.Webshop.Medias
{
    public class Book : Media
    {
        public string? Author { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public DataSet.Language Language { get; set; }
        public DataSet.Genre Genre { get; set; }
    }
}
