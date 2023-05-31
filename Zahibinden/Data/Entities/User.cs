using Microsoft.AspNetCore.Identity;

namespace Zahibinden.Data.Entities
{
    public class User : IdentityUser
    {
        public ICollection<Advert> Adverts { get; set; }

    }
}
