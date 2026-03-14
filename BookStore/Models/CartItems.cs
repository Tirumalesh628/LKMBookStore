using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class CartItems
    {

        public int CartItemsId { get; set; }
        public int? cartid { get; set; }
        public Cart cart { get; set; }

        public int bookid { get; set; }
        public Book book { get; set; }

        public int Quanitity { get; set; }

        public double Price { get; set; }
        [NotMapped]
        public bool Check { get; set; }

    }
}
