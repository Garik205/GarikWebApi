using DataBase;

namespace GarikWebApi.RequestForBot
{
    public class AddId
    {
        private static ApplicationContext? _db;
        
        public static void GetId(int IdChatTelegram)
        {
            User user = new User();
            user.id = Guid.NewGuid();
            user.firstName = "default";
            user.email = "default";
            user.password = "default";
            user.gender = "default";
            user.IdChatTeg = IdChatTelegram;
            _db?.Users.Add(user);
            _db?.SaveChanges();
        }
    }
}
