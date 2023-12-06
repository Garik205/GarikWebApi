using Telegram.Bot.Exceptions;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;

namespace Bot.Handlers
{
    public class HandlersForBot
    {
        protected static Task ErrorHandler(ITelegramBotClient telegramBotClient, Exception error, CancellationToken cancellationToken)
        {
            var ErrorMessage = error switch  // поле для хранения кода ошибки и её сообщение
            {
                ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => error.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        protected static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try // обработчик ошибок, чтобы бот не лёг в случае ошибок
            {
                switch (update.Type) // для обработки Update
                {
                    case UpdateType.Message:
                        {
                            Console.WriteLine("Пришло новое сообщение.");
                            return;
                        }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }
    }
}
