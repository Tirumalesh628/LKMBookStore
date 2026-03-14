namespace BookStore.Models
{
    public class OrderItems
    {

        public int OrderItemsId { get; set; }

        public int Bookid { get; set; }

        public Book Books { get; set; }

        public int OrderId { get; set; }

        public Order order { get; set; }

        public int Quantity { get; set; }

        public DateTime date { get; set; }

        public double Price { get; set; }

        public string Status { get; set; }


    }
}
