using Domain_Models.Database;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace Domain_Models.Webshop.Users
{
    public class User : IDatabaseEntry
    {
        // Properties
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int PhoneNumber { get; set; }
        public string? Address { get; set; }
       

        // Methods specific to User
        public bool BuyListing(Listing listing) { return true; }
        
        // Methods from IDatabaseEntry
        public virtual void AddDBEntry()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO users_table (name, email, phone, address) OUTPUT Inserted.users_id VALUES (@name, @email, @phone, @address)");
            cmd.Parameters.AddWithValue("@name", Name);
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@phone", PhoneNumber);
            cmd.Parameters.AddWithValue("@address", Address);

            string[] result = DatabaseHandler.FetchFromTable(cmd).Split(DatabaseHandler.FieldDelimiter);

            Id = int.Parse(result[0]);
        }

        public virtual IDatabaseEntry GetDBEntry(int pKey)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM users_table WHERE user_id = @id");
            cmd.Parameters.AddWithValue("@id", pKey);

            string[] result = DatabaseHandler.FetchFromTable(cmd).Split(DatabaseHandler.FieldDelimiter);

            if (result[0] == "EMPTY")
            {
                return this;
            }

            if (result[0] == string.Empty)
                result[0] = "0";
            Id = int.Parse(result[0]);
            if (result[1] == string.Empty)
                result[1] = "0";
            Name = result[1];
            if (result[2] == string.Empty)
                result[2] = "0";
            Email = result[2];
            if (result[3] == string.Empty)
                result[3] = "0";
            PhoneNumber = int.Parse(result[3]);
            if (result[4] == string.Empty)
                result[4] = "0";
            Address = result[4];

            return this;
        }

        public virtual void RemoveDBEntry()
        {
            if (Id == 0)
            {
                return;
            }
            SqlCommand cmd = new SqlCommand("DELETE FROM users_table WHERE user_id = @id");
            cmd.Parameters.AddWithValue("@id", Id);

            DatabaseHandler.FetchFromTable(cmd);

        }

        public virtual bool UpdateDBEntry()
        {
            if (Id == 0)
            {
                return false;
            }
            SqlCommand cmd = new SqlCommand("UPDATE users_table SET name = @name, email = @email, phone = @phone, address = @address WHERE user_id = @id");
            cmd.Parameters.AddWithValue("@id", Id);
            cmd.Parameters.AddWithValue("@name", Name);
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@phone", PhoneNumber);
            cmd.Parameters.AddWithValue("@address", Address);

            DatabaseHandler.FetchFromTable(cmd);
            return true;
        }
    }
}
