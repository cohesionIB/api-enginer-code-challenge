using CohesionIB.ApiEngineer.CodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CohesionIB.ApiEngineer.CodeChallenge.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {
        public Task<User> Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
