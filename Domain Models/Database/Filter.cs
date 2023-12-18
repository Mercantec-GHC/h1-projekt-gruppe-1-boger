using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Models.Database
{
    public class Filter
    {
        public int FetchAmount = 5;
        public int FetchOffset = 0;
        public string SearchTerm = "";
        public int[] TagIds = new int[0];

        public Filter(string searchTerm = "", int[] tagIds = null, int fetchAmount = 5, int fetchOffset = 0)
        {
            FetchAmount = fetchAmount;
            FetchOffset = fetchOffset;
            SearchTerm = searchTerm;
            TagIds = tagIds;
        }



        public string GetSqlCommand()
        {
            string sql = "SELECT l.id FROM listing_table as l ";

            sql += "INNER JOIN media_table AS m ON l.media_id = m.media_id ";
            sql += "INNER JOIN book_table AS book ON book.media_id = m.media_id ";
            sql += "INNER JOIN board_games_table AS boardgame ON boardgame.media_id = m.media_id ";
            sql += "INNER JOIN artist_table AS artist1 ON artist1.artist_id = book.artist_id ";
            sql += "INNER JOIN artist_table AS artist2 ON artist2.artist_id = boardgame.artist_id ";

            sql += $"WHERE ( m.title LIKE '%{SearchTerm}%' OR artist1.name LIKE '%{SearchTerm}%' OR artist2.name LIKE '%{SearchTerm}%' )";

            /*
            if (TagIds.Length > 0)
            {
                sql += " AND (";
                for (int i = 0; i < TagIds.Length; i++)
                {
                    sql += " TagId = " + TagIds[i];
                    if (i < TagIds.Length - 1)
                        sql += " OR";
                }
                sql += ")";
            }
            */

            sql += $"ORDER BY l.id OFFSET {FetchOffset} ROWS FETCH NEXT {FetchAmount} ROWS ONLY;";

            return sql;
        }
    }
}
