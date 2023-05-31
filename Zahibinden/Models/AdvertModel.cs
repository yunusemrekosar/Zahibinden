using Zahibinden.Data.Entities;

namespace Zahibinden.Models
{
    public class AdvertModel
    {
        public string Title { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }
        public City City { get; set; }
        public AdvertType Type { get; set; }
        public double Price { get; set; }
        public string NumberofRooms { get; set; }
        public string? Description { get; set; }
        public string M2 { get; set; }
        public string Address { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
