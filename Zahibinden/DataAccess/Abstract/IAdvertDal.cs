using Zahibinden.Data.Entities;

namespace Zahibinden.DataAccess.Abstract
{
    public interface IAdvertDal: IBaseDal<Advert>
    {
        public List<Advert> GetAdvertsByUserId(int userId);
    }
}
