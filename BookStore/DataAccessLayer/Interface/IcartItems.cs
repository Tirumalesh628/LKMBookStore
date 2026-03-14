using BookStore.Models;

namespace BookStore.DataAccessLayer
{
    public interface IcartItems
    {

        public Task<int> AddCartItems(int id, int? userid);
        //public Task<int> AddRemove(string editCart);
        public Task<List<CartItems>> ViewCart(int? userid);
        public Task Add(int BookId, int? UserId);
        public Task Remove(int BookId, int? UserId);
    }
}
