using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.Models;

namespace DataModels.Interfaces
{
    public interface IMessagesProvider : IDatabaseProvider<Messages>
    {
        /// <summary>
        /// Получает сообщение по ключевому слову
        /// </summary>
        /// <param name="keyWord">Ключевое слово</param>
        /// <returns>Модель данных сообщения</returns>
        public Messages? Get(string keyWord);
    }
}
