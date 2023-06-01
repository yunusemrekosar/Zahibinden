using Zahibinden.Data.Entities;

namespace Zahibinden.Models.ViewModels
{
    public class VM_UpdateAdvert
    {
        public string Title { get; set; }
        public int CategoryId { get; set; }
        //public int UserId { get; set; }
        public int CityId { get; set; }
        public int TypeId { get; set; }
        public double Price { get; set; }
        public string NumberofRooms { get; set; }
        public string? Description { get; set; }
        public string M2 { get; set; }
        public string Address { get; set; }
        public IFormCollection Files { get; set; }
    }
}
