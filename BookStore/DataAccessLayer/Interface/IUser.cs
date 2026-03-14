using BookStore.Models;
namespace BookStore.DataAccessLayer
{
    public interface IUser
    {
        public Task<User> UserById(int id);

        public Task<int> RegisterUser(User user);

        public Task<int> UpdateUser(User user);

        public Task<int> DelateUser(int id);

        public Task<User> LoginUser(string Email, string Password);
    }
}
