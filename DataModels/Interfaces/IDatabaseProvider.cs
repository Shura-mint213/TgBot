using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Interfaces
{
    public interface IDatabaseProvider<T>
    {
        /// <summary>
        /// Получает все элементы из таблицы
        /// </summary>
        /// <returns>Элементы таблицы</returns>
        public IEnumerable<T> Get();
        /// <summary>
        /// Получает элемент из таблицы по его ID
        /// </summary>
        /// <param name="id">ID элемента</param>
        /// <returns>Элемент таблицы</returns>
        public T? Get(int id);
    }
}
