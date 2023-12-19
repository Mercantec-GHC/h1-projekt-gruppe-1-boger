using Domain_Models.Database;
using Microsoft.Data.SqlClient;

namespace Domain_Models.Webshop.Medias
{
    public class BoardGame : Media, IDatabaseEntry
    {
        public string? Developer { get; set; }
        public int MinPlayerCount { get; set; }
        public int MaxPlayerCount { get; set; }
        public int MinAge { get; set; }
        public int PlayTime { get; set; }

        public override void AddDBEntry()
        {
            // Will need some sort of check to see if the book already exists in the database
            // then a check if the media already exists in the database
            base.AddDBEntry();

            SqlCommand cmd = new SqlCommand("INSERT INTO board_games_table (media_id, artist_id, min_players, max_players, min_age, play_time) VALUES (@mediaid, @author, @min_players, @max_players, @min_age, @play_time)");
            cmd.Parameters.AddWithValue("@mediaid", Id);
            cmd.Parameters.AddWithValue("@author", Developer);
            cmd.Parameters.AddWithValue("@min_players", MinPlayerCount);
            cmd.Parameters.AddWithValue("@max_players", MaxPlayerCount);
            cmd.Parameters.AddWithValue("@min_age", MinAge);
            cmd.Parameters.AddWithValue("@play_time", PlayTime);

            DatabaseHandler.FetchFromTable(cmd);
        }

        public override IDatabaseEntry GetDBEntry(int pKey)
        {
            base.GetDBEntry(pKey);

            SqlCommand cmd = new SqlCommand("SELECT * FROM board_games_table WHERE media_id = @id");
            cmd.Parameters.AddWithValue("@id", pKey);

            string[] result = DatabaseHandler.FetchFromTable(cmd).Split(DatabaseHandler.FieldDelimiter);

            Developer = result[1];
            MinPlayerCount = int.Parse(result[2]);
            MaxPlayerCount = int.Parse(result[3]);
            MinAge = int.Parse(result[4]);
            PlayTime = int.Parse(result[5]);

            return this;
        }

        public override void RemoveDBEntry()
        {
            if (Id == 0)
                return;

            SqlCommand cmd = new SqlCommand("DELETE FROM board_games_table WHERE media_id = @id");
            cmd.Parameters.AddWithValue("@id", Id);

            DatabaseHandler.FetchFromTable(cmd);

            base.RemoveDBEntry();
        }

        public override bool UpdateDBEntry()
        {
            if (Id == 0)
                return false;

            base.UpdateDBEntry();

            SqlCommand cmd = new SqlCommand("UPDATE board_games_table SET artist_id = @author, min_players = @min_players, max_players = @max_players, min_age = @min_age, play_time = @play_time WHERE media_id = @id");
            cmd.Parameters.AddWithValue("@id", Id);
            cmd.Parameters.AddWithValue("@author",
                               new Random((int)DateTime.Now.ToOADate()).Next());
            cmd.Parameters.AddWithValue("@min_players", MinPlayerCount);
            cmd.Parameters.AddWithValue("@max_players", MaxPlayerCount);
            cmd.Parameters.AddWithValue("@min_age", MinAge);
            cmd.Parameters.AddWithValue("@play_time", PlayTime);

            DatabaseHandler.FetchFromTable(cmd);

            return true;
        }
    }
}
