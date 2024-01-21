using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.Interfaces;
using Microsoft.Extensions.Configuration;
using ReestrBot.Actions;
using Static.Constants;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ReestrBot
{
    internal class Engine : IEngine
    {
        /// <summary>
        /// Это клиент для работы с Telegram Bot API, который позволяет отправлять сообщения,
        /// управлять ботом, подписываться на обновления и многое другое.
        /// </summary>
        private static ITelegramBotClient _bot;
        /// <summary>
        /// Это объект с настройками работы бота.
        /// Здесь мы будем указывать, какие типы Update мы будем получать, Timeout бота и так далее.
        /// </summary>
        private static ReceiverOptions _receiverOptions;
        /// <summary>
        /// Токен ТГ бота
        /// </summary>
        private static string _botToken;
        /// <summary>
        /// ISO 639-1 код русского языка
        /// </summary>
        private const string russianLanguageCode = "ru";
        public Engine(string botToken)
        {
            _botToken = botToken;
            // Проверяем что токен есть
            if (!string.IsNullOrWhiteSpace(botToken))
            {
                _bot = new TelegramBotClient(botToken);

                _receiverOptions = new ReceiverOptions()
                {
                    AllowedUpdates = new[] // Тут указываем типы получаемых Update`ов
                    {
                    UpdateType.Message,
                    UpdateType.CallbackQuery// Сообщения (текст, фото/видео, голосовые/видео сообщения и т.д.)
                },
                    // Параметр, отвечающий за обработку сообщений, пришедших за то время, когда ваш бот был оффлайн
                    // True - не обрабатывать, False (стоит по умолчанию) - обрабаывать
                    ThrowPendingUpdates = true
                };
            }
            else
            {
                throw new Exception("Токена доступа к тг бота не удалось получить");
            }
        }

        /// <summary>
        /// обработчик приходящих Update`ов
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="update"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Обязательно ставим блок try-catch, чтобы наш бот не "падал" в случае каких-либо ошибок
            try
            {
                // Сразу же ставим конструкцию switch, чтобы обрабатывать приходящие Update
                switch (update.Type)
                {
                    case UpdateType.Message:
                        // Эта переменная будет содержать в себе все связанное с сообщениями
                        var message = update.Message;
                        // From - это от кого пришло сообщение (или любой другой Update)
                        var user = message.From;
                        // Выводим на экран то, что пишут нашему боту, а также небольшую информацию об отправителе
                        Console.WriteLine($"{user.FirstName} ({user.Id})  написал сообщение: ID сообщения {message.MessageId} {message.Text} ");
                        // Chat - содержит всю информацию о чате
                        var chat = message.Chat;
                        // Добавляем проверку на тип Message
                        switch (message.Type)
                        {
                            // Тут понятно, текстовый тип
                            case MessageType.Text:
                                // Инициализируем класс действий для текста
                                TextAction textAction = new(_bot, message);
                                // Вызываем метод обработки текста
                                await textAction.Processing();
                                break;
                            // Добавил default , чтобы показать вам разницу типов Message
                            default:
                                await botClient.SendTextMessageAsync(
                                    chat.Id,
                                    "Используйте только текст!");
                                break;
                        }
                        break;

                    case UpdateType.CallbackQuery:
                        // Переменная, которая будет содержать в себе всю информацию о кнопке, которую нажали
                        var callbackQuery = update.CallbackQuery;
                        // Аналогично и с Message мы можем получить информацию о чате, о пользователе и т.д.
                        var userCallbackQuery = callbackQuery.From;
                        // Выводим на экран нажатие кнопки
                        Console.WriteLine($"{userCallbackQuery.FirstName} ({userCallbackQuery.Id}) нажал на кнопку: {callbackQuery.Data}");
                        // Мы пишем не callbackQuery.Chat , а callbackQuery.Message.Chat , так как
                        // кнопка привязана к сообщению, то мы берем информацию от сообщения.
                        var chatcallbackQuery = callbackQuery.Message.Chat;
                        // Инициализируем класс действий для текста
                        CallbackQueryAction callbackQueryAction = new(_bot, callbackQuery);
                        // Вызываем метод обработки текста
                        await callbackQueryAction.Processing();
                        break;
                }
            }           
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Метод для обработки ошибок ТГ бота
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="exception">Ошибка</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
            // Проверяем есть ли токен ТГ бота
            if (!string.IsNullOrWhiteSpace(_botToken))
            {
                // Если токен есть запускаем бота заново 
                Engine engine = new(_botToken);
                await engine.Start();
            }
        }

        /// <summary>
        /// Получения команд для "меню команд" ТГ бота
        /// </summary>
        /// <returns>Команды</returns>
        private List<BotCommand> getBotCommands()
        {
            return new List<BotCommand>()
            {
                new BotCommand() { Command = "/menu", Description = "Меню"},
                new BotCommand() { Command = "/services", Description = "Сервисы"},
                new BotCommand() { Command = "/frequent_questions_shareholders", Description = "Часто задаваемые вопросы акционеров"},
                new BotCommand() { Command = "/frequent_questions_emitents", Description = "Часто задаваемые вопросы эмитентов"},
            };
        }

        /// <summary>
        /// Старт для ТГ бота
        /// </summary>
        /// <returns></returns>
        public async Task Start()
        {
            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;


            List<BotCommand> botCommandList = getBotCommands();
            // Настраиваем бота
            await _bot.SetMyCommandsAsync(botCommandList, languageCode: russianLanguageCode);
            //await _bot.SetMyNameAsync(Settings.BotName, russianLanguageCode);
            await _bot.SetMyDescriptionAsync(Settings.BotDescription, russianLanguageCode);
            await _bot.SetMyShortDescriptionAsync(Settings.BotShortDescription, russianLanguageCode);

            _bot.StartReceiving(
                UpdateHandler,
                HandleErrorAsync,
                _receiverOptions,
                cancellationToken
            );

            Console.WriteLine("Запущен бот " + _bot.GetMeAsync().Result.FirstName);
            Console.ReadKey();
        }
    }
}
