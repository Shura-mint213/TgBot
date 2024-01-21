using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    /// <summary>
    /// Модель данных сообщений
    /// </summary>
    public class Messages
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public int MessageId { get; set; }
        /// <summary>
        /// Ключевое слово
        /// </summary>
        public string KeyWord { get; set; }
        /// <summary>
        /// Ответ на ключевое слово в чате
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Предыдущий ID вопроса
        /// </summary>
        public int? PrevMessageId { get; set; }
        /// <summary>
        /// Следующий ID вопроса 
        /// </summary>
        public int NextTypeId { get; set; }
        /// <summary>
        /// Тип сообщения
        /// </summary>
        public int MessageType { get; set; }
    }
}
