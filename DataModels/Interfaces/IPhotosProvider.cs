using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.Models;

namespace DataModels.Interfaces
{
    public interface IPhotosProvider : IDatabaseProvider<Photos>
    {
        /// <summary>
        /// Получает фотографию прикрепленную к сообщению
        /// </summary>
        /// <param name="messageId">ID сообщения</param>
        /// <returns>Модель данных фотографии</returns>
        IEnumerable<Photos> GetByMessageId(int messageId);
    }
}
