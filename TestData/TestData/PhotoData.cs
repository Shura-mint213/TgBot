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
                    Url = "https://www.aoreestr.ru/upload/iblock/f64/consult_s1_ban.jpg",
                },
            };
        }
    }
}
