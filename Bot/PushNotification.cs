

using Telegram.Bot;
using Telegram.Bot.Types;

namespace Bot
{
    public class PushNotification
    {
        ITelegramBotClient? botClient;
        public async Task SendMessageAsync(ChatId chatId, string message)
        {
            await botClient.SendTextMessageAsync(chatId, message);
        }
    }
}
