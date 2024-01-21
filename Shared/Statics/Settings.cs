using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Statics
{
    public static class Settings
    {
        /// <summary>
        /// Какой режим работы включен если тестовый - true, иначе false
        /// </summary>
        public static bool IsTest { get; set; }
        /// <summary>
        /// Название ТГ бота
        /// </summary>
        public static string BotName { get; set; }
        /// <summary>
        /// Описание ТГ бота 
        /// </summary>
        public static string BotDescription { get; set; }
        /// <summary>
        /// Краткое описание ТГ бота
        /// </summary>
        public static string BotShortDescription { get; set; }
    }
}
