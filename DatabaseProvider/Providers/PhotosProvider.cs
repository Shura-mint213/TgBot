using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.Interfaces;
using DataModels.Models;

namespace DatabaseProvider.Providers
{
    public class PhotosProvider : IPhotosProvider
    {
        public IEnumerable<Photos> Get()
        {
            throw new NotImplementedException();
        }

        public Photos Get(int id)
        {
            throw new NotImplementedException();
        }

        public Photos? GetByMessageId(int messageId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Photos> IPhotosProvider.GetByMessageId(int messageId)
        {
            throw new NotImplementedException();
        }
    }
}
