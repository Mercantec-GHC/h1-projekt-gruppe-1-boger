using Domain_Models.Database;
using Microsoft.Data.SqlClient;

namespace Domain_Models.Webshop
{
    public class Tag : IDatabaseEntry
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public void AddDBEntry()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO tag_table (tag) OUTPUT Inserted.tag_id VALUES (@name)");
            cmd.Parameters.AddWithValue("@name", Name);

            string[] result = DatabaseHandler.FetchFromTable(cmd).Split(DatabaseHandler.FieldDelimiter);

            Id = int.Parse(result[0]);

        }

        public IDatabaseEntry GetDBEntry(int pKey)
        {
            if (pKey == 0)
                return null;

            SqlCommand cmd = new SqlCommand("SELECT * FROM tag_table WHERE tag_id = @id");
            cmd.Parameters.AddWithValue("@id", pKey);

            string[] result = DatabaseHandler.FetchFromTable(cmd).Split(DatabaseHandler.FieldDelimiter);

            Id = int.Parse(result[0]);
            Name = result[1];

            return this;
        }

        public void RemoveDBEntry()
        {
            if (Id == 0)
                return;

            SqlCommand cmd = new SqlCommand("DELETE FROM tag_table WHERE tag_id = @id");
            cmd.Parameters.AddWithValue("@id", Id);

            DatabaseHandler.FetchFromTable(cmd);
        }

        public bool UpdateDBEntry()
        {
            if (Id == 0)
                return false;

            SqlCommand cmd = new SqlCommand("UPDATE tag_table SET tag = @name WHERE tag_id = @id");
            cmd.Parameters.AddWithValue("@id", Id);
            cmd.Parameters.AddWithValue("@name", Name);

            DatabaseHandler.FetchFromTable(cmd);

            return true;
        }
    }
}