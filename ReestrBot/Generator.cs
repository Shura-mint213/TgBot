using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseProvider.Providers;
using DataModels.Interfaces;
using DataModels.Models;
using ReestrBot.Extensions;
using Static.Enums;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TestData.Providers;

namespace ReestrBot
{
    public class Generator
    {
        private readonly int _messageId;
        private readonly IButtonsProvider _buttonsProvider;
        private readonly IMessagesProvider _messagesProvider;
        private readonly IPhotosProvider _photosProvider;
        /// <summary>
        /// Максимальная длина одного поста
        /// </summary>
        private const int _postLength = 4096;
        public Generator(int messageId)
        {
            _messageId = messageId;
            _buttonsProvider = new ButtonsProviderTest();
            _messagesProvider = new MessagesProviderTest();
            _photosProvider = new PhotosProviderTest();
        }

        /// <summary>
        /// Генерирует фотографии к сообщению 
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public InputFileUrl? PhotoGenerate()
        {
            // TODO: сделать возможность, что несколько фотография присвоено к одному сообщению
            // Пока присваиваем одну фотографию
            Photos? photo = _photosProvider.GetByMessageId(_messageId).FirstOrDefault();
            if (photo != null)
            {
                return InputFile.FromUri(photo.Url);
            } 
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Генерирует список сообщений
        /// </summary>
        /// <returns>Список сообщений</returns>
        public List<string> TextSendGenerate()
        {
            string response = string.Empty;
            // Получаем по messageId значения которое пользователь отправил до этого
            Messages? message = _messagesProvider.Get(_messageId);

            if (message != null)
            {
                response = message.Content;
            }

            List<string> postsWithAnswers = new List<string>();
            // Проверяем длина текста не превышает ли предел одного сообщения
            if (response.Length > _postLength)
            {
                // Разбиваем один текст на несколько с длинной _postLength
                postsWithAnswers = response.Split(_postLength).ToList();
            }
            else
            {
                postsWithAnswers.Add(response);
            }

            return postsWithAnswers;
        }

        /// <summary>
        /// Генерирует кнопки к сообщению
        /// </summary>
        /// <param name="messageId">ID Сообщения к которому прикреплены кнопки</param>
        /// <returns>Кнопки прикрепленные к сообщению</returns>
        public IReplyMarkup ButtonGenerate()
        {
            // Получаем информацию сообщения по его ID
            Messages message = _messagesProvider.Get(_messageId);
            // Получаем 
            IEnumerable<Buttons> buttons = _buttonsProvider.Get().Where(k => k.MessageId == _messageId);
            // Список кнопок
            var ikbs = new List<InlineKeyboardButton>();
            // Класс кнопок на экране
            var ikm = new InlineKeyboardMarkup(new List<InlineKeyboardButton>());
            // Перебираем все кнопки которые прикреплены к сообщению и добавляем их в список
            foreach (Buttons button in buttons)
            {
                if (button.ButtonType == (byte)ButtonType.WithUrl)
                {
                    ikbs.Add(InlineKeyboardButton.WithUrl(button.Content, button.Url));
                }
                else if (button.ButtonType == (byte)ButtonType.WithCallbackData)
                {
                    ikbs.Add(InlineKeyboardButton
                        .WithCallbackData(button.Content, button.СallbackData));
                }
            }
            // Если есть ID предыдущего сообщения, добавляем кнопку в список для перехода назад
            if (message.PrevMessageId != null)
            {
                ikbs.Add(InlineKeyboardButton
                    .WithCallbackData("Назад", $"/back-{message.PrevMessageId}"));
            }

            ikm = new InlineKeyboardMarkup(ikbs);

            return ikm;
        }
    }
}
