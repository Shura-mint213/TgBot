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
    public class PhotosProviderTest : IPhotosProvider
    {
        private readonly PhotoData _photoData;

        public PhotosProviderTest()
        {
            _photoData = new PhotoData();
        }
        public IEnumerable<Photos> Get()
        {
            return _photoData.GetPhotos();
        }

        public Photos? Get(int id)
        {
            return _photoData.GetPhotos().FirstOrDefault(i => i.PhotoId == id);
        }

        public IEnumerable<Photos> GetByMessageId(int messageId)
        {
            return _photoData.GetPhotos().Where(i => i.MessageId == messageId);
        }
    }
}
