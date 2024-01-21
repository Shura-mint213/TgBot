using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.Models;

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
                //new Messages { MessageId = 4, KeyWord = "/frequent_questions_shareholders", Content = TextMessages.QuestionsShareholders, PrevMessageId = 3 },
                //new Messages { MessageId = 5, KeyWord = "/frequent_questions_emitents", Content = TextMessages.QuestionsEmitents, PrevMessageId = 3},
            };
        }
    }
}
