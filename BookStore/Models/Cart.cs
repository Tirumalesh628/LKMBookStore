using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Cart
    {

        public int CartId { get; set; }

        public List<CartItems>? CartItems { get; set; }

        public int UserId { get; set; }

        public User user { get; set; }
        [NotMapped]
        public double TotalPrice { get; set; }
    }
}
