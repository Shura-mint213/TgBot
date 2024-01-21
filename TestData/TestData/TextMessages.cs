using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestData.TestData
{
    internal class TextMessages
    {
        public const string WordsOfGreeting = "<b>Здравствуйте!!!</b>\nДля начала работы напишите /start\n";
        public const string WordServices = "\n\n<b>Сервисы: </b>\n <a>Первый</a>\n<a>Второй</a>\n<a>Третий</a>\n";
        public const string WordStart = "<b>Полезная информация:</b>\n<b>Для акционера</b> - <a> Личный кабинет Клиента</a> " + WordServices;
        public const string WordHelp = "<b>Вы можете воспользоваться командами:</b>\n\n/services - сервысы\n/frequent_questions_shareholders - часто задаваемые вопросы акционеров\n/frequent_questions_emitents - часто задаваемые вопросы эмитентов";}
}
