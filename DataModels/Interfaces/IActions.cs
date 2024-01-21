using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Interfaces
{
    public interface IActions
    {
        /// <summary>
        /// Обрабатывает действия в ТГ
        /// </summary>
        /// <returns></returns>
        public Task Processing();
    }
}
