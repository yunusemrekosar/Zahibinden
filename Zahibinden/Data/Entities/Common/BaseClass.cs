using System.ComponentModel.DataAnnotations;

namespace Zahibinden.Data.Entities.Common
{
    public class BaseClass
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public virtual bool IsActive { get; set; }    

    }
}
