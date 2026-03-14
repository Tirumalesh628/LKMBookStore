namespace BookStore.Models
{
    public class User
    {

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public long Phone { get; set; }

        public Cart cart { get; set; }

        public Order order { get; set; }
    }
}
