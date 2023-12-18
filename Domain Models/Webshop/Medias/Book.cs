using Domain_Models.Database;
using Domain_Models.Enums;
using Microsoft.Data.SqlClient;

namespace Domain_Models.Webshop.Medias
{
    public class Book : Media 
    {
        public string? Author { get; set; } = "Empty";
        public int Year { get; set; } = 2021;
        public int Pages { get; set; } = 100;
        public LANGUAGE Language { get; set; } = LANGUAGE.ENGLISH;
        public GENRE Genre { get; set; }

        public override void AddDBEntry()
        {
            // Will need some sort of check to see if the book already exists in the database
            // then a check if the media already exists in the database
            base.AddDBEntry();

            SqlCommand cmd = new SqlCommand("INSERT INTO book_table (media_id, artist_id, year, pages, language) VALUES (@mediaid, @author, @year, @pages, @language)");
            cmd.Parameters.AddWithValue("@mediaid", Id);
            cmd.Parameters.AddWithValue("@author", new Random((int)DateTime.Now.ToOADate()).Next());
            cmd.Parameters.AddWithValue("@year", Year);
            cmd.Parameters.AddWithValue("@pages", Pages);
            cmd.Parameters.AddWithValue("@language", $"{Language}");

            DatabaseHandler.FetchFromTable(cmd);
        }

        public override IDatabaseEntry GetDBEntry(int pKey)
        {
            base.GetDBEntry(pKey);

            SqlCommand cmd = new SqlCommand("SELECT * FROM book_table WHERE media_id = @id");
            cmd.Parameters.AddWithValue("@id", pKey);

            string[] result = DatabaseHandler.FetchFromTable(cmd).Split(DatabaseHandler.FieldDelimiter);

            
            Author = result[1];
            Year = int.Parse(result[2]);
            Pages = int.Parse(result[3]);
            Language = (LANGUAGE)int.Parse(result[4]);

            return this;
        }

        public override void RemoveDBEntry()
        {
            if (Id == 0)
                return;

            SqlCommand cmd = new SqlCommand("DELETE FROM book_table WHERE media_id = @id");
            cmd.Parameters.AddWithValue("@id", Id);

            DatabaseHandler.FetchFromTable(cmd);

            base.RemoveDBEntry();
        }

        public override bool UpdateDBEntry()
        {
            if (Id == 0)
                return false;
            
            base.UpdateDBEntry();
            
            SqlCommand cmd = new SqlCommand("UPDATE book_table SET artist_id = @author, year = @year, pages = @pages, language = @language WHERE media_id = @id");
            cmd.Parameters.AddWithValue("@id", Id);
            cmd.Parameters.AddWithValue("@author", 1);
            cmd.Parameters.AddWithValue("@year", Year);
            cmd.Parameters.AddWithValue("@pages", Pages);
            cmd.Parameters.AddWithValue("@language", $"{Language}");

            DatabaseHandler.FetchFromTable(cmd);

            return true;
        }
    }
}
