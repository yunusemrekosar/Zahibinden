using Zahibinden.Data;
using Zahibinden.Data.Entities;
using Zahibinden.DataAccess.Abstract;

namespace Zahibinden.DataAccess.Concrete
{
    public class CityDal : BaseDal<City>, ICityDal
    {
        private readonly ApplicationDbContext _context;

        public CityDal(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
