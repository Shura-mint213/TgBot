using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.Models;
using Static.Enums;

namespace TestData.TestData
{
    internal class MessageData
    {        
        internal List<Messages> GetMessages()
        {
            return new List<Messages>()
            {
                new Messages { MessageId = 1, KeyWord = "/start", Content = TextMessages.WordStart, PrevMessageId = 1 },
                new Messages { MessageId = 2, KeyWord = "/menu", Content = TextMessages.WordHelp, },
                new Messages { MessageId = 3, KeyWord = "/help", Content = TextMessages.WordHelp, PrevMessageId = 3 },
                new Messages { MessageId = 3, KeyWord = "/services", Content = TextMessages.WordServices, PrevMessageId = 2 },
                new Messages { MessageId = 4, KeyWord = "/frequent_questions_shareholders", Content = TextMessages.QuestionsShareholders, PrevMessageId = 3 },
                new Messages {MessageId = 5, KeyWord = "/frequent_questions_emitents", Content = TextMessages.QuestionsEmitents, PrevMessageId = 3},
                new Messages { MessageId = 6, KeyWord = "/questions_emitent1", Content = TextOfAnswersToQuestions.QuestionsEmitent1, PrevMessageId = 5},
                new Messages { MessageId = 7, KeyWord = "/questions_emitent2", Content = TextOfAnswersToQuestions.QuestionsEmitent2, PrevMessageId = 5},
                new Messages { MessageId = 8, KeyWord = "/questions_emitent3", Content = TextOfAnswersToQuestions.QuestionsEmitent3, PrevMessageId = 5},
                new Messages { MessageId = 9, KeyWord = "/questions_emitent4", Content = TextOfAnswersToQuestions.QuestionsEmitent4, PrevMessageId = 5},
                new Messages { MessageId = 10, KeyWord = "/questions_emitent5", Content = TextOfAnswersToQuestions.QuestionsEmitent5, PrevMessageId = 5},
                new Messages { MessageId = 11, KeyWord = "/questions_shareholder1", Content = TextOfAnswersToQuestions.QuestionsShareholder1, PrevMessageId = 4},
                new Messages { MessageId = 12, KeyWord = "/questions_shareholder2", Content = TextOfAnswersToQuestions.QuestionsShareholder2, PrevMessageId = 4},
                new Messages { MessageId = 13, KeyWord = "/questions_shareholder3", Content = TextOfAnswersToQuestions.QuestionsShareholder3, PrevMessageId = 4},
                new Messages { MessageId = 14, KeyWord = "/questions_shareholder4", Content = TextOfAnswersToQuestions.QuestionsShareholder4, PrevMessageId = 4},
                new Messages { MessageId = 15, KeyWord = "/questions_shareholder5", Content = TextOfAnswersToQuestions.QuestionsShareholder5, PrevMessageId = 4},
            };
        }
    }
}
