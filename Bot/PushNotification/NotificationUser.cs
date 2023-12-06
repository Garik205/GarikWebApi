

using Telegram.Bot;

namespace Bot.PushNotification
{
    public class NotificationUser
    {
        public static async Task Push()
        {
            TelegramBotClient botClient = new TelegramBotClient("6543089403:AAG0KkWyvB8LIbX7BhQB1S9Vpl9MoSpYdz4");
            await botClient.SendTextMessageAsync(chatId: 997805424, text: "Hello world");
        }

    }
}
