using Domain_Models.Webshop;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Domain_Models.Database
{
    public static class DatabaseHandler
    {
        private static SqlConnection _connection;
        private static bool _isConnected = false;

        public static string FieldDelimiter = "|";
        public static string RowDelimiter = "\n";
        public static bool IsConnected { get => _isConnected; set => _isConnected = value; }

        public static bool Create(string? connectionstring = "Server=tcp:secondhandbooks.database.windows.net,1433;Initial Catalog=SecondhandBooksDB;Persist Security Info=False;User ID=secbookadmin;Password=Prideandprejudice!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        {
            if (connectionstring == "none")
                connectionstring = Environment.GetEnvironmentVariable("connectionstring");

            try
            {
               
                _connection = new SqlConnection(connectionstring);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        private static bool Connect()
        {
            if (_connection == null)
                Create();

            try
            {
                _connection.Open();
                IsConnected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        private static bool Disconnect()
        {
            try
            {
                _connection.Close();
                IsConnected = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public static string GetDBEntry(int pKey, string tablename)
        {
            throw new NotImplementedException();
        }

        public static string GetDatabaseEntries()
        {
            throw new NotImplementedException();
        }

        public static void TryAddDBEntry()
        {
            throw new NotImplementedException();
        }

        public static void TryRemoveDBEntry()
        {
            throw new NotImplementedException();
        }

        public static bool TryUpdateDBEntry()
        {
            throw new NotImplementedException();
        }


        public static string FetchFromTable(SqlCommand cmd)
        {
            if (cmd == null)
            {
                return "Error";
            }

            Connect();
            // Console.WriteLine(cmd.ExecuteScalar().ToString());
            cmd.Connection = _connection;


            SqlDataReader reader = cmd.ExecuteReader();
            StringBuilder response = new StringBuilder();
            
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        response.Append(reader.GetValue(i));
                        if (i < reader.FieldCount - 1)
                        {
                            response.Append(FieldDelimiter); // Add FieldDelimiter only if it's not the last field
                        }
                    }
                    response.Append(RowDelimiter); // Add RowDelimiter at the end of each row
                }
            }
            else
            {
                response.Append("EMPTY");
            }

            reader.Close();
            Disconnect();
            return response.ToString();
        }

        public static Listing[] Search(Filter filter)
        {
            // TODO: Implement search
            string results = FetchFromTable(filter.GetSqlCommand());


            if (results == "EMPTY")
                return new Listing[0];

            string[] rowArray = results.Split(RowDelimiter);

            List<Listing> listings = new List<Listing>();

            for (int i = 0; i < rowArray.Length; i++)
            {
                Console.WriteLine(rowArray[i]);
                string[] resultArray = rowArray[i].Split(FieldDelimiter);
                if (resultArray[0] == string.Empty)
                    continue;
                listings.Add(new Listing());
                listings[i].GetDBEntry(int.Parse(resultArray[0]));
                
            }


            return listings.ToArray();
        }


    }
}
