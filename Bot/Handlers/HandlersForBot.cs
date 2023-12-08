using Telegram.Bot.Exceptions;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using DataBase;
using Microsoft.EntityFrameworkCore;

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
            //AddId addId = new AddId();

            try // обработчик ошибок, чтобы бот не лёг в случае ошибок
            {
                switch (update.Type) // для обработки Update
                {
                    case UpdateType.Message:
                        {
                            Console.WriteLine("Пришло новое сообщение.");
                            Console.WriteLine($"User: {(update.Message)?.Chat.FirstName}, ID: {(update.Message)?.Chat.Id}");
                            botClient?.SendTextMessageAsync(chatId: update.Message.Chat.Id, text: "Ты написал мне сообщение? А зря! Настрой меня сначала по нормальному... а потом и поговорим!");
                            //AddId.GetId((int)update.Message.Chat.Id);

                            using (var context = new ApplicationContext())
                            {
                                var ctxUser = context.Users
                                    .FirstOrDefault(_ => _.IdChatTeg == update.Message.Chat.Id);

                                if (ctxUser != null)
                                    return;

                                var user = new DataBase.User()
                                {
                                    id = Guid.NewGuid(),
                                    IdChatTeg = (int)update.Message.Chat.Id,
                                    email = "default",
                                    firstName = "default",
                                    gender = "default",
                                    password = "default",
                                };

                                context.Users.Add(user);
                                context.SaveChanges();
                            }

                            return;
                        }
                        default: break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
