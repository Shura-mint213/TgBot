using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    /// <summary>
    /// Модель данных фотографии
    /// </summary>
    public class Photos
    {
        /// <summary>
        /// ID фотографии
        /// </summary>
        public int PhotoId { get; set; }
        /// <summary>
        /// ID сообщения
        /// </summary>
        public int MessageId { get; set; }
        /// <summary>
        /// Ссылка на фотографию 
        /// </summary>
        public string Url { get; set; }
    }
}
