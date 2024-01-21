using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using DataModels.Models;
using DataModels.Interfaces;
using DatabaseProvider.Providers;
using Telegram.Bot.Types.ReplyMarkups;
using TestData.Providers;

namespace ReestrBot.Actions
{
    public class TextAction
    {
        private readonly ITelegramBotClient _bot;
        private readonly Message _message;
        private readonly IMessagesProvider _messagesProvider;
        /// <summary>
        /// Chat - содержит всю информацию о чате
        /// </summary>
        private readonly ChatId _chatId;
        public TextAction(ITelegramBotClient bot, Message message)
        {
            if (message == null) throw new ArgumentNullException("message");
            if (bot == null) throw new ArgumentNullException("bot");

            _bot = bot;
            _message = message;
            _chatId = _message.Chat;
            _messagesProvider = new MessagesProviderTest();
        }
        /// <summary>
        /// Обрабатывает действие связанное с типом сообщения в ТГ MessageType.Text
        /// </summary>
        /// <returns></returns>
        public async Task Processing()
        {
            Messages? message = _messagesProvider.Get(_message.Text);
            // Проверяем удалось ли найти сообщения по ключевому слову
            if (message != null || string.IsNullOrWhiteSpace(message.Content)) 
            {
                IReplyMarkup? ikm = null;
                List<string> postsWithAnswers = new();
                InputFileUrl? fileUrl = null;
                Generator generator = new(message.MessageId);
                // Генерируем сообщения
                postsWithAnswers = generator.TextSendGenerate();
                // Генерируем кнопки
                ikm = generator.ButtonGenerate();
                // Генерируем фотографию
                fileUrl = generator.PhotoGenerate();

                Answers answers = new(_bot);
                // Отправляем ответное сообщение
                await answers.SendPostAsync(_chatId, fileUrl, postsWithAnswers, ikm);
            }
            else
            {
                return;
            }
        }
    }
}
