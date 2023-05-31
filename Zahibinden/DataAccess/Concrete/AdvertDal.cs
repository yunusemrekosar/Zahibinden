using Zahibinden.Data;
using Zahibinden.Data.Entities;
using Zahibinden.DataAccess.Abstract;

namespace Zahibinden.DataAccess.Concrete
{
    public class AdvertDal : BaseDal<Advert>, IAdvertDal
    {
        private readonly ApplicationDbContext _context;

        public AdvertDal(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Advert> GetAdvertsByUserId(string userId)
        {
            return _context.Adverts.Where(x=>x.UserId == userId).ToList();
        }
    }
}
