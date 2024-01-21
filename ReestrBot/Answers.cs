using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace ReestrBot
{
    public class Answers
    {
        private readonly ITelegramBotClient _bot;
        public Answers(ITelegramBotClient bot) 
        { 
            _bot = bot;
        }

        /// <summary>
        /// Отправляет сообщения пользователю в ТГ 
        /// </summary>
        /// <param name="chatId">ID ТГ чата</param>
        /// <param name="fileUrl">Фотография в сообщении</param>
        /// <param name="postsWithAnswers">Списки отправляемых сообщений</param>
        /// <param name="buttons">Кнопки в сообщении</param>
        /// <returns></returns>
        public async Task SendPostAsync(ChatId chatId, InputFileUrl fileUrl, List<string> postsWithAnswers, IReplyMarkup buttons)
        {
            // TODO переделать чтобы не несколько сообщения отправлялось а одно с возможностью page`инга 
            // Урезать количество символов отправляемых одним сообщением, чтобы стало удобочитаемее
            // Отправляем список сообщений 
            for (int index = 0, firstElementIndex = 0; index < postsWithAnswers.Count; index++)
            {
                if (fileUrl != null && index == firstElementIndex)
                {
                    // Переделать на случай если будет много текста и нужно будет разбить на несколько сообщений
                    await _bot.SendPhotoAsync(chatId, photo: fileUrl, caption: postsWithAnswers[firstElementIndex], parseMode: ParseMode.Html);
                }
                // Если сообщение последнее прикрепляем к сообщению кнопки если они есть
                else if (index == postsWithAnswers.Count - 1)
                {
                    await _bot.SendTextMessageAsync(chatId, postsWithAnswers[index], parseMode: ParseMode.Html, replyMarkup: buttons);
                }
                else
                {
                    await _bot.SendTextMessageAsync(chatId, postsWithAnswers[index], parseMode: ParseMode.Html);
                }
            }
        }
    }
}
