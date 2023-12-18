using Domain_Models.Database;
using Domain_Models.Webshop.Medias;

namespace Domain_Models.Webshop.Users
{
    public class Seller : User
    {
        // Properties
        public int Id { get; set; }
        public int Rating { get; set; }
        public List<Listing> Listings { get; set; } = new List<Listing>();

        // Methods specific to Seller
        public bool CreateListing(Media media) { return true; }

        public override void AddDBEntry()
        {
            base.AddDBEntry();
        }

        public override IDatabaseEntry GetDBEntry(int pKey)
        {
            return base.GetDBEntry(pKey);
        }

        public override void RemoveDBEntry()
        {
            base.RemoveDBEntry();
        }

        public override bool UpdateDBEntry()
        {
            return base.UpdateDBEntry();
        }
    }
}