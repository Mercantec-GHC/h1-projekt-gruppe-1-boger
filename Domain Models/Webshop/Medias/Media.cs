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

            string[] result = DatabaseHandler.FetchFromTable(cmd).Split("/n");

            Id = int.Parse(result[0]);
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
