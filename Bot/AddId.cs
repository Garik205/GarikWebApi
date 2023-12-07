
using Microsoft.Data.Sqlite;
using Telegram.Bot.Types;

namespace Bot
{
    public class AddId
    {

        public static void GetId(int update)
        {
            using (var connection = new SqliteConnection("Data Source=DBuser.db"))
            {
                connection.Open();

                SqliteCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = $"INSERT INTO Users (IdChatTeg) VALUES ({update})";
            }
        }
        
    }
}
