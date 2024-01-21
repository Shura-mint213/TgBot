using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReestrBot.Extensions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;
using DataModels.Interfaces;
using TestData.Providers;
using DataModels.Models;
using System.Reflection.Emit;

namespace ReestrBot.Actions
{
    /// <summary>
    /// Класс для обработки Callback`ов
    /// </summary>
    public class CallbackQueryAction : IActions
    {
        private readonly ITelegramBotClient _bot;
        private readonly CallbackQuery _callbackQuery;
        private IMessagesProvider _messagesProvider;
        public CallbackQueryAction(ITelegramBotClient bot, CallbackQuery callbackQuery)
        {
            _bot = bot;
            _callbackQuery = callbackQuery;
            _messagesProvider = new MessagesProviderTest();
        }

        public async Task Processing()
        {
            // Если нет никаких данных в callbackQuery ничего не делаем
            if (string.IsNullOrWhiteSpace(_callbackQuery.Data))
            {
                return;
            }
            string dataCallbackQuery = _callbackQuery.Data;
            // ID чата
            ChatId chatId = _callbackQuery.From.Id;
            int messageId = 0;
            IReplyMarkup? ikm = null;
            List<string> postsWithAnswers = new();
            InputFileUrl? fileUrl = null;
            // Проверяем являеться ли колбек "шаг назад"
            if (dataCallbackQuery.Contains("/back", StringComparison.CurrentCultureIgnoreCase))
            {                
                // Отсикаем от данных в колбеке часть с "/back-" и получаем 
                // ID сообщения на которое нужно перейти
                string messageIdStr = dataCallbackQuery.Replace("/back-", "");
                // Парсим строку в число
                if (int.TryParse(messageIdStr, out messageId))
                {
                    Generator generator = new Generator(messageId);
                    // Генерируем сообщения
                    postsWithAnswers = generator.TextSendGenerate();
                    // Генерируем кнопки
                    ikm = generator.ButtonGenerate();
                    // Генерируем фотографию
                    fileUrl = generator.PhotoGenerate();
                } 
                else
                {
                    throw new InvalidCastException("Ошибка при конвертации ID сообщения из строки в число.");
                }                
            }

            // Если нет ID сообщения ничего не делаем
            if (messageId > 0)
            {
                Answers answers = new(_bot);
                // Отправляем ответное сообщение
                await answers.SendPostAsync(chatId, fileUrl, postsWithAnswers, ikm);

            }
            else
            {
                return;
            }
        }
    }
}
