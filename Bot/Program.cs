using Bot.Handlers;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;


namespace Bot
{
    class Program : HandlersForBot
    {
        private static ITelegramBotClient? _botClient; // Клиент для работы с Telegram Bot Api (Позволяет отправлять сообщения, управлять ботом, подписываться на обновления и прочее)

        private static ReceiverOptions? _receiverOptions; // Объект с настройками работы бота. Позволяет указывать какие типы Update мы будем получать, Timeout бота и прочее

        

        static async Task Main() 
        {
            _botClient = new TelegramBotClient("6543089403:AAG0KkWyvB8LIbX7BhQB1S9Vpl9MoSpYdz4"); // Наш токен полученный от бота

            _receiverOptions = new ReceiverOptions() // Присваемваем значение для настройки бота
            {

                AllowedUpdates = new[] // Тип получаемых Update
                {
                    UpdateType.Message, // Можем получить сообщения(текст, фото и другую инфу) 
                },
                ThrowPendingUpdates = true, // параметр, который отвечает за обработку полученных сообщений во время нахожения бота в offline режиме. True - не надо обрабатывать, False - надо обрабатывать.
            };

            

            using var cts = new CancellationTokenSource();

            _botClient.StartReceiving(UpdateHandler, ErrorHandler, _receiverOptions, cts.Token);
            // UpdateHandler - обработчик приходящих Update
            // ErrorHandler - обработчик ошибок для Bot API

            var me = await _botClient.GetMeAsync(); // поле для хранения информации о моём боте

            Console.WriteLine($"{me.FirstName} мой бот запущен ");

            _botClient?.SendTextMessageAsync(chatId: 997805424, text: "Привет!) Ты меня запустил, но я ещё ничего не умею...");

            await Task.Delay(-1);

            
        }
    }
}