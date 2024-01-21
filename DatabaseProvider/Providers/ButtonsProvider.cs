using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.Interfaces;
using DataModels.Models;

namespace DatabaseProvider.Providers
{
    public class ButtonsProvider : IButtonsProvider
    {
        public IEnumerable<Buttons> Get()
        {
            throw new NotImplementedException();
        }

        public Buttons Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Buttons> GetByMessageId(int messageId)
        {
            throw new NotImplementedException();
        }
    }
}
