using Zahibinden.Data;
using Zahibinden.Data.Entities;
using Zahibinden.DataAccess.Abstract;

namespace Zahibinden.DataAccess.Concrete
{
    public class AdvertTypeDal : BaseDal<AdvertType>, IAdvertTypeDal
    {
        private readonly ApplicationDbContext _context;

        public AdvertTypeDal(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
