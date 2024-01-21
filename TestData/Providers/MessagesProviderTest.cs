using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.Interfaces;
using DataModels.Models;
using TestData.TestData;

namespace TestData.Providers
{
    public class MessagesProviderTest : IMessagesProvider
    {
        private readonly MessageData _messageData;

        public MessagesProviderTest()
        {
            _messageData = new MessageData();
        }
        public IEnumerable<Messages> Get()
        {
            return _messageData.GetMessages();
        }

        public Messages? Get(int id)
        {
            return _messageData.GetMessages().FirstOrDefault(i => i.MessageId == id);
        }

        public Messages? Get(string keyWord)
        {
            return _messageData.GetMessages().FirstOrDefault(i => i.KeyWord == keyWord);
        }
    }
}
