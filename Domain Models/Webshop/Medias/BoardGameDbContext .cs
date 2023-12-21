using Domain_Models.Database;
using Domain_Models.Enums;
using Microsoft.Data.SqlClient;

using static System.Net.Mime.MediaTypeNames;

namespace Domain_Models.Webshop.Medias
{
    public class BoardGameDbContext
    {
        
        
        public BoardGame Add(BoardGame boardGame)
        {
            DatabaseHandler.Create();

            SqlCommand cmd = new SqlCommand("INSERT INTO board_games_table (media_id, artist_id, min_players, max_players, min_age, play_time) VALUES (@media_id, @author, @min_players, @max_players, @min_age, @play_time)");
            cmd.Parameters.AddWithValue("@media_id", boardGame.Id);
            cmd.Parameters.AddWithValue("@author", boardGame.Developer);
            cmd.Parameters.AddWithValue("@min_players", boardGame.MinPlayerCount);
            cmd.Parameters.AddWithValue("@max_players", boardGame.MaxPlayerCount);
            cmd.Parameters.AddWithValue("@min_age", boardGame.MinAge);
            cmd.Parameters.AddWithValue("@play_time", boardGame.PlayTime);

            string[] result = DatabaseHandler.FetchFromTable(cmd).Split(DatabaseHandler.FieldDelimiter);
            var id = int.Parse(result[0]);

            return Get(id);
        }

        public BoardGame Get(int id)
        {
            DatabaseHandler.Create();

            
            SqlCommand cmd = new SqlCommand("SELECT b.media_id, m.title, b.artist_id, m.[description], b.min_players, b.max_players, b.min_age, b.play_time, m.original_price FROM board_games_table b INNER JOIN media_table m on b.media_id = m.media_id WHERE media_id = @id");
            cmd.Parameters.AddWithValue("@id", id);
            

            string[] result = DatabaseHandler.FetchFromTable(cmd).Split(DatabaseHandler.FieldDelimiter);

            BoardGame boardGame = new BoardGame();
            boardGame.Id = int.Parse(result[0]);
            boardGame.Title = result[1];
            boardGame.Developer = result[2];
            boardGame.Description = result[3];
            boardGame.MinPlayerCount = int.Parse(result[4]);
            boardGame.MaxPlayerCount = int.Parse(result[5]);
            boardGame.MinAge = int.Parse(result[6]);
            boardGame.PlayTime = int.Parse(result[7]);
            boardGame.Price = int.Parse(result[8]);

            return boardGame;

        }

        public List<BoardGame> GetAll()
        {
            var boardGames = new List<BoardGame>();

            DatabaseHandler.Create();

            SqlCommand cmd = new SqlCommand("SELECT b.media_id, m.title, b.artist_id, m.[description], b.min_players, b.max_players, b.min_age, b.play_time, m.original_price FROM board_games_table b INNER JOIN media_table m on b.media_id = m.media_id;");

            string[] result = DatabaseHandler.FetchFromTable(cmd).Split(DatabaseHandler.RowDelimiter);

            foreach (var row in result)
            {
                if (row == "")
                {
                    break;
                }
                Console.WriteLine(row);
                var fields = row.Split(DatabaseHandler.FieldDelimiter);
                BoardGame boardGame = new BoardGame();
                boardGame.Id = int.Parse(fields[0]);
                boardGame.Title = fields[1];
                boardGame.Developer = fields[2];
                boardGame.Description = fields[3];
                boardGame.MinPlayerCount = int.Parse(fields[4]);
                boardGame.MaxPlayerCount = int.Parse(fields[5]);
                boardGame.MinAge = int.Parse(fields[6]);
                boardGame.PlayTime = int.Parse(fields[7]);
                boardGame.Price = float.Parse(fields[8]);

                boardGames.Add(boardGame);
            }

            
            return boardGames;
        }

        public BoardGame Update(BoardGame boardGame)
        {
            DatabaseHandler.Create();

            SqlCommand cmd = new SqlCommand("UPDATE board_games_table SET artist_id = @author, min_players = @min_players, max_players = @max_players, min_age = @min_age, play_time = @play_time WHERE media_id = @id");
            cmd.Parameters.AddWithValue("@id", boardGame.Id);
            cmd.Parameters.AddWithValue("@author", boardGame.Developer);
            cmd.Parameters.AddWithValue("@min_players", boardGame.MinPlayerCount);
            cmd.Parameters.AddWithValue("@max_players", boardGame.MaxPlayerCount);
            cmd.Parameters.AddWithValue("@min_age", boardGame.MinAge);
            cmd.Parameters.AddWithValue("@play_time", boardGame.PlayTime);

            DatabaseHandler.FetchFromTable(cmd);

            return this.Get(boardGame.Id);
        }

        public void Delete(BoardGame boardGame)
        {

            DatabaseHandler.Create();

            SqlCommand cmd = new SqlCommand("DELETE FROM board_games_table WHERE media_id = @id");
            cmd.Parameters.AddWithValue("@id", boardGame.Id);

            DatabaseHandler.FetchFromTable(cmd);
        }
    }
}
