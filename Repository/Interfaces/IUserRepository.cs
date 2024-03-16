using Seat_broker_backend.Models;
using Seat_broker_backend.Models.Dto;

namespace Seat_broker_backend.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetUserByEmail(string EmailId);

        Task<User> GetUserByUserName(string userName);

        Task AddUser(User user);
    }
}
