using Zahibinden.Data;
using Zahibinden.Data.Entities;
using Zahibinden.DataAccess.Abstract;

namespace Zahibinden.DataAccess.Concrete
{
    public class CategoryDal : BaseDal<Category>, ICategoryDal
    {
        private readonly ApplicationDbContext _context;

        public CategoryDal(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
