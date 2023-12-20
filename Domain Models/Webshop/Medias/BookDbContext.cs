using Domain_Models.Database;
using Domain_Models.Enums;
using Microsoft.Data.SqlClient;

namespace Domain_Models.Webshop.Medias
{
    public class BookDbContext
    {
        private Dictionary<string, Enum> language;
        public BookDbContext() {
            this.language = new Dictionary<string, Enum>();
            language.Add("ENGLISH", Domain_Models.Enums.LANGUAGE.ENGLISH);
            language.Add("SWEDISH", Domain_Models.Enums.LANGUAGE.SWEDISH);
            language.Add("SPANISH", Domain_Models.Enums.LANGUAGE.SPANISH);
            language.Add("JAPANESE", Domain_Models.Enums.LANGUAGE.JAPANESE);
            language.Add("DANISH", Domain_Models.Enums.LANGUAGE.DANISH);
            language.Add("PORTUGUESE", Domain_Models.Enums.LANGUAGE.PORTUGUESE);
        }
        public Book Add(Book book)
        {
            DatabaseHandler.Create();

            SqlCommand cmd = new SqlCommand("INSERT INTO book_table (media_id, artist_id, year, pages, language) VALUES (@mediaid, @author, @year, @pages, @language)");
            cmd.Parameters.AddWithValue("@mediaid", book.Id);
            cmd.Parameters.AddWithValue("@author", book.Author);
            cmd.Parameters.AddWithValue("@year", book.Year);
            cmd.Parameters.AddWithValue("@pages", book.Pages);
            cmd.Parameters.AddWithValue("@language", $"{book.Language}");

            string[] dbOut = DatabaseHandler.FetchFromTable(cmd).Split(DatabaseHandler.FieldDelimiter);
            var id = int.Parse(dbOut[0]);

            return Get(id);
        }

        public Book Get(int id)
        {
            DatabaseHandler.Create();

            //SqlCommand cmd = new SqlCommand("SELECT * FROM book_table WHERE media_id = @id");
            SqlCommand cmd = new SqlCommand("SELECT b.media_id, m.title, b.artist_id, m.[description], b.[year], b.pages, b.[language], b.genre, m.original_price FROM book_table b INNER JOIN media_table m on b.media_id = m.media_id WHERE media_id = @id");
            cmd.Parameters.AddWithValue("@id", id);

            string[] result = DatabaseHandler.FetchFromTable(cmd).Split(DatabaseHandler.FieldDelimiter);

            Book book = new Book();
            book.Id = int.Parse(result[0]);
            book.Title = result[1];
            book.Author = result[2];
            book.Description = result[3];
            book.Year = int.Parse(result[4]);
            book.Pages = int.Parse(result[5]);
            book.Language = (Domain_Models.Enums.LANGUAGE)language[result[6]];
            book.Price = float.Parse(result[8]);
            return book;

        }

        public List<Book> GetAll()
        {
            var books = new List<Book>();

            DatabaseHandler.Create();

            SqlCommand cmd = new SqlCommand("SELECT b.media_id, m.title, b.artist_id, m.[description], b.[year], b.pages, b.[language], b.genre, m.original_price FROM book_table b INNER JOIN media_table m on b.media_id = m.media_id;");

            string[] result = DatabaseHandler.FetchFromTable(cmd).Split(DatabaseHandler.RowDelimiter);

            foreach (var row in result)
            {
                if (row == "")
                {
                    break;
                }
                Console.WriteLine(row);
                var fields = row.Split(DatabaseHandler.FieldDelimiter);
                Book book = new Book();
                book.Id = int.Parse(fields[0]);
                book.Title = fields[1];
                book.Author = fields[2];
                book.Description = fields[3];
                book.Year = int.Parse(fields[4]);
                book.Pages = int.Parse(fields[5]);
                book.Language = (Domain_Models.Enums.LANGUAGE)language[fields[6]];
                book.Price = float.Parse(fields[8]);

                books.Add(book);
            }

            
            return books;
        }

        public Book Update(Book book)
        {
            DatabaseHandler.Create();

            SqlCommand cmd = new SqlCommand("UPDATE book_table SET artist_id = @author, year = @year, pages = @pages, language = @language WHERE media_id = @id");
            cmd.Parameters.AddWithValue("@id", book.Id);
            cmd.Parameters.AddWithValue("@author", book.Author);
            cmd.Parameters.AddWithValue("@year", book.Year);
            cmd.Parameters.AddWithValue("@pages", book.Pages);
            cmd.Parameters.AddWithValue("@language", $"{book.Language}");

            DatabaseHandler.FetchFromTable(cmd);

            return this.Get(book.Id);
        }

        public void Delete(Book book)
        {

            DatabaseHandler.Create();

            SqlCommand cmd = new SqlCommand("DELETE FROM book_table WHERE media_id = @id");
            cmd.Parameters.AddWithValue("@id", book.Id);

            DatabaseHandler.FetchFromTable(cmd);
        }
    }
}
