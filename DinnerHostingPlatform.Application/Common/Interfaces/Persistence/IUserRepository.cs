using DinnerHostingPlatform.Domain.Entities;

namespace DinnerHostingPlatform.Application.Common.Interfaces.Persistence
{
   public interface IUserRepository
   {
      // we need to support two features while login/registeration:
      // 1. create a new user
      void AddUser(User user);
      // 2. get a user by emai address
      User? GetUserByEmail(string email);
   }
}