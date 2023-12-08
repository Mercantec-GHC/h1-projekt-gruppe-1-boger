using Domain_Models.Database;

namespace Domain_Models.Webshop.Users
{
    public class User : IDatabaseEntry
    {
        // Properties
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }

        // Methods specific to User
        public bool BuyListing(Listing listing) { return true; }
        
        // Methods from IDatabaseEntry
        public void AddDBEntry()
        {
            throw new NotImplementedException();
        }

        public IDatabaseEntry GetDBEntry(int pKey)
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
