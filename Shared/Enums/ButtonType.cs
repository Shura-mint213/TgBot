using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Enums
{
    public enum ButtonType : byte
    {
        /// <summary>
        /// Обычная кнопка с Callback`ом
        /// </summary>
        WithCallbackData = 0,
        /// <summary>
        /// Кнопка по нажатию на которую перебрасывает на указанный ресурс
        /// </summary>
        WithUrl,
    }
}
