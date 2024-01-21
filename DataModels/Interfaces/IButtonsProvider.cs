using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.Models;

namespace DataModels.Interfaces
{
    public interface IButtonsProvider : IDatabaseProvider<Buttons>
    {
        /// <summary>
        /// Ищет все кнопки привязанные к сообщению
        /// </summary>
        /// <param name="messageId">ID сообщения</param>
        /// <returns>Модели кнопок привязанных к сообщению</returns>
        IEnumerable<Buttons> GetByMessageId(int messageId);
    }
}
