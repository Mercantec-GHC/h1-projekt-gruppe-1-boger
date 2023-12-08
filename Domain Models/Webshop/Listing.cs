using Domain_Models.Database;
using Domain_Models.Enums;
using Domain_Models.Webshop.Medias;
using Domain_Models.Webshop.Users;

namespace Domain_Models.Webshop
{
    public class Listing : IDatabaseEntry
    {
        // Properties
        public int ID { get; set; }
        public int Price { get; set; }
        public Media Item { get; set; }
        public Seller Seller { get; set; }
        public CONDITION Condition { get; set; }

        // Methods specific to Listing
        public bool TryUpdateListing() { return true; }
        public bool TryRemoveListing() { return true; }

        // Methods from IDatabaseEntry
        public IDatabaseEntry GetDBEntry(int pKey)
        {
            throw new NotImplementedException();
        }

        public void AddDBEntry()
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