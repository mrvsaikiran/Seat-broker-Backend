using Microsoft.EntityFrameworkCore;
using Seat_broker_backend.Context;
using Seat_broker_backend.Models;
using Seat_broker_backend.Models.Dto;
using Seat_broker_backend.Repository.Interfaces;

namespace Seat_broker_backend.Repository.Implentations
{
    public class UserRepostory : IUserRepository
    {
        private readonly AppDbContext _db;
        
        public UserRepostory(AppDbContext db) {
          _db= db;
        }
        public async  Task<IEnumerable<User>> GetAllUsers()
        {

            IEnumerable<User> usersList= await _db.Users.ToListAsync();

            return usersList;
        
        }

        public async Task<User> GetUserByEmail(string EmailId)
        {
           User user= await _db.Users.Where(x=>x.Email==EmailId).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            User user = await _db.Users.Where(x => x.UserName == userName).FirstOrDefaultAsync();
            return user;
        }

        public async Task AddUser(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();            
        }
    }
}
