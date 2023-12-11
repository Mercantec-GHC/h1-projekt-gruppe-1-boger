using Domain_Models.Database;

namespace Domain_Models.Webshop.Medias
{
    public class Media : IDatabaseEntry
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<Tag>? Tags { get; set; }
        public int Price { get; set; }
        public string ImagePath { get; set; } = "Images/images.png";

        public virtual void AddDBEntry()
        {
            throw new NotImplementedException();
        }

        public virtual IDatabaseEntry GetDBEntry(int pKey)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveDBEntry()
        {
            throw new NotImplementedException();
        }

        public virtual bool UpdateDBEntry()
        {
            throw new NotImplementedException();
        }
    }
}
