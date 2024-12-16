namespace Restaurants.Domain.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { set; get; } = default!;
        public string? Description { set; get; }
        public string Category { set; get; } = default!;
        public bool HasDelivery { set; get; } = default!;
        
        public string? ContactEmail { set; get; }
        public string? ContactNumber { set; get; }
        public Address? Address { set; get; }
        public List<Dish> Dishes { set; get; } = new();


    }
}
