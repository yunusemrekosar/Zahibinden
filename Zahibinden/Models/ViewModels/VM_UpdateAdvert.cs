using Zahibinden.Data.Entities;

namespace Zahibinden.Models.ViewModels
{
    public class VM_UpdateAdvert
    {
        public string Title { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public Guid CityId { get; set; }
        public Guid TypeId { get; set; }
        public double Price { get; set; }
        public string NumberofRooms { get; set; }
        public string? Description { get; set; }
        public string M2 { get; set; }
        public string Address { get; set; }
        public IFormCollection Files { get; set; }
    }
}
