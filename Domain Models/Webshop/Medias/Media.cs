namespace Domain_Models.Webshop.Medias
{
    public class Media
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<Tag>? Tags { get; set; }
        public int Price { get; set; }
        public string ImagePath { get; set; } = "Images/images.png";
    }
}
