using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    /// <summary>
    /// Модель данных кнопки
    /// </summary>
    public class Buttons
    {
        /// <summary>
        /// ID кнопки
        /// </summary>
        public int ButtonMessageId { get; set; }
        /// <summary>
        /// Тип кнопки
        /// </summary>
        public byte ButtonType { get; set; }
        /// <summary>
        /// ID сообщения к которому прекреплина кнопка
        /// </summary>
        public int MessageId { get; set; }
        /// <summary>
        /// Контект кнопки 
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Колбек кнопки 
        /// </summary>
        public string СallbackData { get; set; }
        /// <summary>
        /// Ссылка на ресурс (если кнопка перебрасывает куда то)
        /// </summary>
        public string Url { get; set; }
    }
}
