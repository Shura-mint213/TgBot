using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.Models;

namespace TestData.TestData
{
    public class PhotoData
    {
        public List<Photos> GetPhotos()
        {
            return new List<Photos> { new Photos
                {
                    PhotoId = 1,
                    MessageId = 1,
                    Url = "https://robokassa.com/upload/medialibrary/12e/12ec7d81223bf2b07bf44e4e36333677.jpg",
                },
            };
        }
    }
}
