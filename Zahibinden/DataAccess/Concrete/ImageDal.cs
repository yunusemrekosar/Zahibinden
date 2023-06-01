using Zahibinden.Data;
using Zahibinden.Data.Entities;
using Zahibinden.DataAccess.Abstract;

namespace Zahibinden.DataAccess.Concrete
{
    public class ImageDal : BaseDal<Image>, IImageDal
    {
        private readonly ApplicationDbContext _context;

        public ImageDal(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
