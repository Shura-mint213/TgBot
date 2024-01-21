using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.Interfaces;
using DataModels.Models;

namespace DatabaseProvider.Providers
{
    public class MessagesProvider : IMessagesProvider
    {
        public IEnumerable<Messages> Get()
        {
            throw new NotImplementedException();
        }

        public Messages Get(int id)
        {
            throw new NotImplementedException();
        }

        public Messages? Get(string keyWord)
        {
            throw new NotImplementedException();
        }
    }
}
