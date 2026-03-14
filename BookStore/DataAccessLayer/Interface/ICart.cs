using BookStore.Models;

namespace BookStore.DataAccessLayer
{
    public interface ICart
    {

        public Task<Cart> GetCart(int? UserID);
        public Task<int> Addcart(int Id);

        public Task<int> GetCartId(int? UserID);
    }
}
