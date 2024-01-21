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
    public class ButtonsProviderTest : IButtonsProvider
    {
        private readonly ButtonData _buttonData;

        public ButtonsProviderTest()
        {
            _buttonData = new ButtonData();
        }

        public IEnumerable<Buttons> Get()
        {
            return _buttonData.GetButtonMessages();
        }

        public Buttons? Get(int id)
        {
            return _buttonData.GetButtonMessages().FirstOrDefault(i => i.ButtonMessageId == id);
        }

        public IEnumerable<Buttons> GetByMessageId(int messageId)
        {
            return _buttonData.GetButtonMessages().Where(i => i.MessageId == messageId);
        }
    }
}
