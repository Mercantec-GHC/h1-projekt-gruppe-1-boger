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
