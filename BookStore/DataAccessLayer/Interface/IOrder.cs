using BookStore.Models;

namespace BookStore.DataAccessLayer
{
    public interface IOrder
    {

        public Task<Order> GetListOfOrders(int? userid);

        public Task<int> PlaceOrderIndividual(int bookid, int? userid);

        public Task<int> CreateOrder(int? userid);
        public Task<int> PlaceOrderFromcart(int Id, int? userid);


    }
}
