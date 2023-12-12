using Domain_Models.Database;
using Microsoft.Data.SqlClient;

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
            SqlCommand cmd = new SqlCommand("INSERT INTO media_table (title, description, original_price, image_path) OUTPUT Inserted.media_id VALUES (@title, @description, @price, @imagepath)");
            cmd.Parameters.AddWithValue("@title", Title);
            cmd.Parameters.AddWithValue("@description", Description);
            cmd.Parameters.AddWithValue("@price", Price);
            cmd.Parameters.AddWithValue("@imagepath", ImagePath);

            string[] result = DatabaseHandler.FetchFromTable(cmd).Split(DatabaseHandler.FieldDelimiter);

            Id = int.Parse(result[0]);
        }

        public virtual IDatabaseEntry GetDBEntry(int pKey)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM media_table WHERE media_id = @id");
            cmd.Parameters.AddWithValue("@id", pKey);

            string[] result = DatabaseHandler.FetchFromTable(cmd).Split(DatabaseHandler.FieldDelimiter);

            Id = int.Parse(result[0]);
            Title = result[1];
            Description = result[2];
            Price = int.Parse(result[3]);
            ImagePath = result[4];

            return this;
        }

        public virtual void RemoveDBEntry()
        {
            if (Id == 0)
            {
                return;
            }
            SqlCommand cmd = new SqlCommand("DELETE FROM media_table WHERE media_id = @id");
            cmd.Parameters.AddWithValue("@id", Id);

            DatabaseHandler.FetchFromTable(cmd);

        }

        public virtual bool UpdateDBEntry()
        {
            throw new NotImplementedException();
        }
    }
}
