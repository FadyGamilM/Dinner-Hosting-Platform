using DinnerHostingPlatform.Application.Common.Interfaces.Persistence;
using DinnerHostingPlatform.Domain.Entities;

namespace DinnerHostingPlatform.Infrastructure.Persistence
{
   public class UserRepository : IUserRepository
   {
      // In memory database
      private static readonly List<User> _users = new();
      public void AddUser(User user)
      {
         _users.Add(user);
      }
      public User? GetUserByEmail(string email)
      {
         return _users.FirstOrDefault(user => user.Email == email);
      }
   }
}