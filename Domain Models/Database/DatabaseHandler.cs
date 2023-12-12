using Microsoft.Data.SqlClient;

namespace Domain_Models.Database
{
    public static class DatabaseHandler
    {
        private static SqlConnection _connection;
        private static bool _isConnected = false;

        public static string FieldDelimiter = "\n";
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
            Connect();

            if (cmd == null)
            {
                return "Error";
            }

            cmd.Connection = _connection;

            SqlDataReader reader = cmd.ExecuteReader();
            string response = "";
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    response += reader.GetValue(i) + " ";
                }
            }   response += FieldDelimiter;

            return response;
        }


    }
}
