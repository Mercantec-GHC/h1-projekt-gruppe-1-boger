using Domain_Models.Database;
using Domain_Models.Webshop.Medias;

namespace Domain_Models.Webshop.Users
{
    public class Seller : User
    {
        // Properties
        public int Rating { get; set; }
        public List<Listing> Listings { get; set; } = new List<Listing>();

        // Methods specific to Seller
        public bool CreateListing(Media media) { return true; }

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