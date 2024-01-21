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
        public const string WordServices = "\n\n<b>Сервисы: </b>\n<a href=\"https://forms.aoreestr.ru/\">Сервис заполнения форм</a>" +
            "\n<a href=\"https://services.aoreestr.ru/MeetingCalculator\">Калькулятор дат собрания</a>\n<a href=\"https://www.aoreestr.ru/shareholders/lichnyy-kabinet-aktsionera/\">Инвестиционная платформа</a>" +
            "\n<a href=\"https://lk.aoreestr.ru/login.aspx?ReturnUrl=%2f\">Личный кабинет эмитента</a>\n<a href=\"https://online.aoreestr.ru/transitional\">Личный кабинет акционера</a>" +
            "\n<a href=\"https://services.aoreestr.ru/DocumentStatus\">Проверка исходящего документа</a>";
        public const string WordStart = "<b>Полезная информация:</b>\n<b>Для акционера - </b> <a href=\"https://www.aoreestr.ru/shareholders/lichnyy-kabinet-aktsionera/\">Личный кабинет Клиента</a>" +
            "\n\r\n<b>Для эмитентов - </b> <a href=\"https://lk.aoreestr.ru/login.aspx\">Личный кабинет Эмитента</a>" + WordServices;
        public const string WordHelp = "<b>Вы можете воспользоваться командами:</b>\n\n/services - сервысы\n/frequent_questions_shareholders - часто задаваемые вопросы акционеров\n/frequent_questions_emitents - часто задаваемые вопросы эмитентов";
        public const string QuestionsEmitents = "<b>Часто задаваемые вопросы эмитентов:</b>\n\n" +
            "Какие документы необходимо предоставить для открытия лицевого счета физическому лицу? - /questions_emitent1\n" +
            "Какие документы необходимо предоставить для открытия лицевого счета российскому юридическому лицу? - /questions_emitent2\n" +
            "Какие документы необходимо предоставить для открытия лицевого счета иностранному юридическому лицу? - /questions_emitent3\n" +
            "Фкциями владел умерший родственник. Как оформить наследство? - /questions_emitent4\n" +
            "Что делать, если пропущен срок принятия наследства? - /questions_emitent5\n";
        public const string QuestionsShareholders = "<b>Часто задаваемые вопросы акционеров:</b>\n\n" +
            "Какие документы необходимо предоставить для открытия лицевого счета физическому лицу? - /questions_shareholder1\n" +
            "Какие документы необходимо предоставить для открытия лицевого счета российскому юридическому лицу? - /questions_shareholder2\n" +
            "Какие документы необходимо предоставить для открытия лицевого счета иностранному юридическому лицу? - /questions_shareholder3\n" +
            "Фкциями владел умерший родственник. Как оформить наследство? - /questions_shareholder4\n" +
            "Что делать, если пропущен срок принятия наследства? - /questions_shareholder5\n";
    }
}
