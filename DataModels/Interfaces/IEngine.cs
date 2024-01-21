using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Interfaces
{
    public interface IEngine
    {
        /// <summary>
        /// Старт для ТГ бота
        /// </summary>
        /// <returns></returns>
        public Task Start();
    }
}
