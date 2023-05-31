using Zahibinden.Data;
using Zahibinden.Data.Entities.Common;

namespace Zahibinden.DataAccess
{
    public class BaseDal<T> : IBaseDal<T> where T : BaseClass
    {
        private readonly ApplicationDbContext _context;

        public BaseDal(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(T t)
        {
            _context.Set<T>().Add(t);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var t = GetById(id);
            t.IsActive = false;
            _context.SaveChanges();
            return true;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Where(x=>x.Id == id).FirstOrDefault();
        }

        public bool Update(T t)
        {
            _context.Set<T>().Update(t);
            _context.SaveChanges();
            return true;
        }
    }
}
