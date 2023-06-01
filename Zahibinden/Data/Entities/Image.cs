using System.ComponentModel.DataAnnotations.Schema;
using Zahibinden.Data.Entities.Common;

namespace Zahibinden.Data.Entities
{
    public class Image : BaseClass
    {
        public Advert Advert { get; set; }
        public int AdvertId { get; set; }
        public string ImagePath { get; set; }
    }
}
