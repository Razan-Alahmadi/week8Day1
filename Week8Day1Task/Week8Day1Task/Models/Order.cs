namespace Week8Day1Task.Models
{
    public class Order
    {
    public int OrderId { get; set; } 
        public int UserId { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public User User { get; set; }

    }
}
