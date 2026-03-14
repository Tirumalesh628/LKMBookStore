using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Order
    {

        public int OrderId { get; set; }

        public int? userid { get; set; }

        public User user { get; set; }

        public List<OrderItems> orderItems { get; set; }

        [NotMapped]

        public double TotalPrice { get; set; }

    }
}
